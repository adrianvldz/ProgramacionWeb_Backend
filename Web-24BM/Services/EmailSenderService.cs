using System.Net.Mail;
using System.Net;

namespace Web_24BM.Services
{
    public class EmailSenderService : IEmailSenderServices
    {
        public bool SendEmail(string email)
        {
            bool result = false;

            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient smtpClient = new SmtpClient("mail.shapp.mx", 587);

                smtpClient.EnableSsl = true;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential("moises.puc@shapp.mx", "Dhaserck_999");

                mail.From = new MailAddress("moises.puc@shapp.mx", "Administrador");
                mail.To.Add(email);
                mail.Subject = "Aviso de contacto";
                mail.IsBodyHtml = true;
                mail.Body = $"Se ha contactado a la persona con el correo {email} para su contacto";

                smtpClient.Send(mail);

                result = true;

            }
            catch (Exception ex) { 


            }

            return result;
            
        }
    }
}
