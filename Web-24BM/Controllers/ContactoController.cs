using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Mail;

namespace Web_24BM.Controllers
{
    public class ContactoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult EnviarEmail(string email, string comentario)
        {
            TempData["EmailT"] = email;
            TempData["ComentarioT"] = comentario;
            EnviarEmailSmtp(email);
            return View("Index" , "Contacto");
        }

        public IActionResult Contacto()
        {
            return View();
        }

        public bool EnviarEmailSmtp(string email)
        {
            MailMessage mail = new MailMessage();
            SmtpClient smtpClient = new SmtpClient("mail.shapp.mx", 587);

            smtpClient.EnableSsl = true;
            smtpClient.UseDefaultCredentials= false;
            smtpClient.Credentials = new NetworkCredential("moises.puc@shapp.mx", "Dhaserck_999");

            mail.From = new MailAddress("moises.puc@shapp.mx", "Administrador");
            mail.To.Add(email);
            mail.IsBodyHtml= true;
            mail.Body = $"Se ha contactado a la persona con el correo {email} para su contacto";

            smtpClient.Send(mail);


            return true;
        }
    }
}
