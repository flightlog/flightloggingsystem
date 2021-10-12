using MimeKit;
using System.Net.Mail;

namespace FLS.EmailService.Extensions
{
    public static class MailAddressExtensions
    {
        public static MailboxAddress ToMailKitMailboxAddress(this MailAddress mailAddress)
        {
            return new MailboxAddress(mailAddress.DisplayName, mailAddress.Address);
        }
    }
}
