using System.Collections.Generic;
using System.Net.Mail;
using System.Threading.Tasks;

namespace FLS.EmailService
{
    public interface IEmailService
    {
        Task SendEmailAsync(MailAddress from, MailAddress replyTo, IEnumerable<MailAddress> to, string subject, string textBody, string htmlBody);
    }
}
