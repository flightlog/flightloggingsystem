using FLS.EmailService.Extensions;
using Microsoft.Extensions.Options;
using MimeKit;
using System.Collections.Generic;
using System.IO;
using System.Net.Mail;
using System.Threading.Tasks;

namespace FLS.EmailService
{
    public class MailkitEmailService : IEmailService
    {
        private readonly EmailServiceSettings _mailServiceOptions;

        public MailkitEmailService(IOptions<EmailServiceSettings> options)
        {
            _mailServiceOptions = options.Value;
        }

        public async Task SendEmailAsync(MailAddress from, MailAddress replyTo, IEnumerable<MailAddress> to, string subject, string textBody, string htmlBody)
        {
            var message = new MimeMessage();
            message.From.Add(from.ToMailKitMailboxAddress());
            message.ReplyTo.Add(replyTo.ToMailKitMailboxAddress());

            foreach (var mailAddress in to)
            {
                message.To.Add(mailAddress.ToMailKitMailboxAddress());
            }

            message.Subject = subject;

            var plain = new TextPart(MimeKit.Text.TextFormat.Plain)
            {
                Text = textBody
            };

            var html = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = htmlBody
            };

            // Note: it is important that the text/html part is added second, because it is the
            // most expressive version and (probably) the most faithful to the sender's WYSIWYG 
            // editor.
            // see also: https://github.com/jstedfast/MimeKit
            var alternative = new Multipart("alternative");
            alternative.Add(plain);
            alternative.Add(html);

            message.Body = alternative;

            if (_mailServiceOptions.Testmode || string.IsNullOrEmpty(_mailServiceOptions.SmtpServer))
            {
                var directory = _mailServiceOptions.TestmodeEmailPickupDirectory;
                if (string.IsNullOrEmpty(directory))
                {
                    directory = @"c:\Temp\";
                }

                if (Directory.Exists(directory) == false)
                {
                    Directory.CreateDirectory(directory);
                }

                var fileName = Path.Combine(directory, $"{message.Date.ToString("yyyy-MM-dd_HHmmss")}-{message.Subject}.eml");
                message.WriteTo(fileName);

                return;
            }

            using (var client = new MailKit.Net.Smtp.SmtpClient())
            {
                //TODO: Implement SSL certificate check
                // For demo-purposes, accept all SSL certificates (in case the server supports STARTTLS)
                client.ServerCertificateValidationCallback = (s, c, h, e) => true;

                client.Connect(_mailServiceOptions.SmtpServer, _mailServiceOptions.SmtpPort, _mailServiceOptions.UseSsl);

                if (_mailServiceOptions.UseSmtpAuthentication)
                {
                    client.Authenticate(_mailServiceOptions.SmtpUsername, _mailServiceOptions.SmtpPassword);
                }

                await client.SendAsync(message);
                client.Disconnect(true);

                return;
            }
        }
    }
}
