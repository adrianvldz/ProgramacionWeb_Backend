using Web_24BM.Models;

namespace Web_24BM.Services
{
    public interface IEmailSenderServices
    {
        bool SendEmail(string email);

        bool ProcesarSolicitud(EmailViewModel email);

        bool SendEmailWithData(MensajeViewModel model);
    }
}
