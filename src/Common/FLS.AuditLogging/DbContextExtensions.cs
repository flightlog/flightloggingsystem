﻿using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FLS.AuditLogging
{
    public static class DbContextExtensions
    {
        public static int SaveChangesWithAudit(this DbContext dbContext)
        {
            var auditEntries = OnBeforeSaveChanges(dbContext);
            var result = dbContext.SaveChanges();
            OnAfterSaveChanges(dbContext, auditEntries);
            return result;
        }

        public static async Task<int> SaveChangesWithAuditAsync(this DbContext dbContext, CancellationToken cancellationToken = default(CancellationToken))
        {
            var auditEntries = OnBeforeSaveChanges(dbContext);
            var result = await dbContext.SaveChangesAsync(cancellationToken);
            await OnAfterSaveChanges(dbContext, auditEntries);
            return result;
        }

        /// <summary>
	    /// <seealso cref="https://www.meziantou.net/2017/08/14/entity-framework-core-history-audit-table"/>
	    /// </summary>
        private static List<AuditEntry> OnBeforeSaveChanges(DbContext dbContext)
        {
            dbContext.ChangeTracker.DetectChanges();
            var auditEntries = new List<AuditEntry>();
            foreach (var entry in dbContext.ChangeTracker.Entries())
            {
                if (entry.Entity is AuditLog || entry.State == EntityState.Detached || entry.State == EntityState.Unchanged)
                    continue;

                var auditEntry = new AuditEntry
                {
                    TableName = entry.Metadata.GetTableName(),
                    EntityName = entry.Metadata.Name
                };
                auditEntries.Add(auditEntry);

                foreach (var property in entry.Properties)
                {
                    if (property.IsTemporary)
                    {
                        // value will be generated by the database, get the value after saving
                        auditEntry.TemporaryProperties.Add(property);
                        continue;
                    }

                    string propertyName = property.Metadata.Name;
                    if (property.Metadata.IsPrimaryKey())
                    {
                        auditEntry.KeyValues[propertyName] = property.CurrentValue;
                        continue;
                    }

                    switch (entry.State)
                    {
                        case EntityState.Added:
                            auditEntry.NewValues[propertyName] = property.CurrentValue;
                            auditEntry.EventType = AuditEventType.Added;
                            break;

                        case EntityState.Modified:
                            if (property.IsModified)
                            {
                                auditEntry.OldValues[propertyName] = property.OriginalValue;
                                auditEntry.NewValues[propertyName] = property.CurrentValue;
                            }
                            auditEntry.EventType = AuditEventType.Modified;
                            break;

                        case EntityState.Deleted:
                            auditEntry.OldValues[propertyName] = property.OriginalValue;
                            auditEntry.EventType = AuditEventType.Deleted;
                            break;
                    }
                }
            }

            // Save audit entities that have all the modifications
            foreach (var auditEntry in auditEntries.Where(_ => !_.HasTemporaryProperties))
            {
                dbContext.Add<AuditLog>(auditEntry.ToAuditLog());
            }

            // keep a list of entries where the value of some properties are unknown at this step
            return auditEntries.Where(_ => _.HasTemporaryProperties).ToList();
        }

        /// <summary>
        /// <seealso cref="https://www.meziantou.net/2017/08/14/entity-framework-core-history-audit-table"/>
        /// </summary>
        private static Task OnAfterSaveChanges(DbContext dbContext, List<AuditEntry> auditEntries)
        {
            if (auditEntries == null || auditEntries.Count == 0)
                return Task.CompletedTask;

            foreach (var auditEntry in auditEntries)
            {
                // Get the final value of the temporary properties
                foreach (var prop in auditEntry.TemporaryProperties)
                {
                    if (prop.Metadata.IsPrimaryKey())
                    {
                        auditEntry.KeyValues[prop.Metadata.Name] = prop.CurrentValue;
                    }
                    else
                    {
                        auditEntry.NewValues[prop.Metadata.Name] = prop.CurrentValue;
                    }
                }

                // Save the Audit entry
                dbContext.Add<AuditLog>(auditEntry.ToAuditLog());
            }

            return dbContext.SaveChangesAsync();
        }
    }
}