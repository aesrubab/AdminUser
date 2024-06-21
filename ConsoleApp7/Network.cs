using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp7
{
    internal static class Network
    {
        internal static class MailService 
        {
            public static void SendEmail(string toEmail, string subject, string body)
            {
                var fromEmail = "rubabhuseynova013@gmail.com"; // burda kimin hesabindan mail gedecekse o olacaq
                var fromPassword = "bndl duuu vexw uems"; // Burda iki faktorlu dogrulama zamani yaratdigimiz anahtari yazirig

                var smtpClient = new SmtpClient("smtp.gmail.com") // SMTP serverinin adresi
                {
                    Port = 587, // SMTP serverinin portu
                    Credentials = new NetworkCredential(fromEmail, fromPassword),
                    EnableSsl = true,
                };

                var mailMessage = new MailMessage
                {
                    From = new MailAddress(fromEmail),
                    Subject = subject,
                    Body = body,
                    IsBodyHtml = true,
                };
                mailMessage.To.Add(toEmail);

                try
                {
                    smtpClient.Send(mailMessage);
                    Console.WriteLine($"Email sent to {toEmail}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Failed to send email: {ex.Message}");
                }
            }

        }
    }
}
