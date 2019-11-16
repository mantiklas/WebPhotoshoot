using ASPNetFramework_Angular7_EF.Business.Dtos;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace ASPNetFramework_Angular7_EF.Business.Email
{
    public class EmailSender : IEmailSender
    {
        public void Send(EmailDto emailDto)
        {
            if (emailDto.ToEmails == null)
            {
                return;
            }
            var mailMessage = new MailMessage
            {
                From = new MailAddress(ConfigurationManager.AppSettings["EmailSenderEmailAddress"], "Team Winning"),
                Subject = emailDto.Subject,
                Body = emailDto.Message,
                IsBodyHtml = true,
            };
            foreach (var item in emailDto.PathAttachments)
            {
                mailMessage.Attachments.Add(new Attachment(item));
            }
            foreach (var to in emailDto.ToEmails.Where(x => !string.IsNullOrEmpty(x)))
            {
                mailMessage.To.Add(to);
            }
            foreach (var cc in emailDto.CCEmails)
            {
                mailMessage.CC.Add(cc);
            }

            SendMail(mailMessage);
            mailMessage.Dispose();
        }

        private void SendMail(MailMessage mailMessage)
        {
            var smtpClient = new SmtpClient
            {
                Host = ConfigurationManager.AppSettings["EmailSenderHost"],
                Port = int.Parse(ConfigurationManager.AppSettings["EmailSenderPort"]),
                DeliveryMethod = SmtpDeliveryMethod.Network,
                Credentials = new NetworkCredential(ConfigurationManager.AppSettings["CredUser"], ConfigurationManager.AppSettings["CredPass"]),
                EnableSsl = true
            };

            smtpClient.Send(mailMessage);
        }
    }
}
