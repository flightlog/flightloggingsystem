using Microsoft.EntityFrameworkCore;

namespace FLS.AuditLogging
{
    public interface IAuditableDbContext
    {
        DbSet<AuditLog> AuditLogs { get; set; }
    }
}
