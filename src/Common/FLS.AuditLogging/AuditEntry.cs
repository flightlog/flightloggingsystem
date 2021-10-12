using Microsoft.EntityFrameworkCore.ChangeTracking;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLS.AuditLogging
{
    /// <summary>
    /// <seealso cref="https://www.meziantou.net/2017/08/14/entity-framework-core-history-audit-table"/>
    /// </summary>
    public class AuditEntry
    {
        public string TableName { get; set; }
        public string EntityName { get; set; }
        public Dictionary<string, object> KeyValues { get; } = new Dictionary<string, object>();
        public Dictionary<string, object> OldValues { get; } = new Dictionary<string, object>();
        public Dictionary<string, object> NewValues { get; } = new Dictionary<string, object>();
        public List<PropertyEntry> TemporaryProperties { get; } = new List<PropertyEntry>();
        public string UserName { get; set; }
        public AuditEventType EventType { get; set; }
        public bool HasTemporaryProperties => TemporaryProperties.Any();

        public AuditLog ToAuditLog()
        {
            var serSettings = new JsonSerializerSettings()
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };

            var audit = new AuditLog();
            audit.TableName = TableName;
            audit.EntityName = EntityName;
            audit.AuditDateTime = DateTime.UtcNow;
            audit.KeyValues = JsonConvert.SerializeObject(KeyValues, serSettings);
            audit.OldValues = OldValues.Count == 0 ? null : JsonConvert.SerializeObject(OldValues, serSettings);
            audit.NewValues = NewValues.Count == 0 ? null : JsonConvert.SerializeObject(NewValues, serSettings);
            audit.UserName = UserName;
            audit.EventType = EventType.ToString();
            return audit;
        }
    }
}
