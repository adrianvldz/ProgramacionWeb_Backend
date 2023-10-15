using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;
using System.Net;
using Web_24BM.Models;
using Web_24BM.Services;

namespace Web_24BM.Controllers
{
    public class FormularioController : Controller
    {
        private readonly IEmailSenderServices _emailSenderServices;

        public FormularioController(IEmailSenderServices emailSenderServices)
        {
            _emailSenderServices = emailSenderServices;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Formulario()
        {
            return View();
        }

        [HttpPost]
        public IActionResult EnviarFormulario(EmailViewModel model)
        {
            
            TempData["EmailT"] = model.Email;
            TempData["ComentarioT"] = model.Mensaje;
            
            ProcesarSolicitud(model);

            var result = _emailSenderServices.SendEmail(model.Email);

            if (!result)
            {
                TempData["EmailT"] = null;

                TempData["EmailError"] = "Ocurrió un error";
            }
            return View("Formulario", model);

        }

        public bool ProcesarSolicitud(EmailViewModel email)
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
                mail.To.Add(email.Email);
                mail.Subject = "Información de contacto: ";
                mail.IsBodyHtml = true;
                mail.Body = $"<p>Se ha contactado el cliente con los siguientes datos:<p>" +
                 $"<p>Nombre: {email.Nombre}<p>" +
                 $"<p>Apellido: {email.Apellido}<p>" +
                 $"<p>Correo: {email.Email}<p>" +
                 $"<p>Fecha de Nacimiento: {email.FechaNacimiento}<p>" +
                 $"<p>Hora de Entrada: {email.HoraEntrada}<p>" +
                 $"<p>Turno: {email.Turno}<p>" +
                 $"<p>Mensaje: {email.Mensaje}<p>";

                smtpClient.Send(mail);

                result = true;

            }
            catch (Exception ex)
            {

            }


            return result;
        }


    }
}
