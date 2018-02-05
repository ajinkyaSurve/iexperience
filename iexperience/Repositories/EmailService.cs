using iexperience.Services;
using iexperience.Entities;
using System.Net.Mail;

namespace iexperience.Repositories
{
    public class EmailService : IEmailService
    {
        public string EmailHost { get; set; }
        public int EmailPort { get; set; }

        public EmailService()
        {
            EmailHost = "smtp.gmail.com";
            EmailPort = 25;
        }

        public bool SendEmail(Email e)
        {
            try
            {
                MailMessage mail = new MailMessage(e.Sender, e.Receipent);
                SmtpClient client = new SmtpClient();
                client.Port = EmailPort;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.Host = EmailHost;
                mail.Subject = e.Subject;
                mail.Body = e.EmailBody;
                client.Send(mail);
                return true;
            }
            catch(SmtpException)
            {
                return false;
            }
        }

    }
}
