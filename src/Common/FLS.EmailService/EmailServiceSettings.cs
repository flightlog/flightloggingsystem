using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLS.EmailService
{
    public class EmailServiceSettings
    {
        public string SmtpServer { get; set; }

        public int SmtpPort { get; set; }

        public bool UseSsl { get; set; }

        public bool UseSmtpAuthentication { get; set; }

        public string SmtpUsername { get; set; }

        public string SmtpPassword { get; set; }

        /// <summary>
        /// Gets or sets the MailService in test mode or not.
        /// If Testmode = true, no email will be sent, instead the mailmessage will be serialized to disk
        /// </summary>
        public bool Testmode { get; set; }

        public string TestmodeEmailPickupDirectory { get; set; }
    }
}
