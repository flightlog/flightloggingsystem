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
    public class AuditLog
    {
        public int Id { get; set; }
        public string TableName { get; set; }
        public string EntityName { get; set; }
        public DateTime AuditDateTime { get; set; }
        public string UserName { get; set; }
        public string KeyValues { get; set; }
        public string OldValues { get; set; }
        public string NewValues { get; set; }
        public string EventType { get; set; }
    }
}
