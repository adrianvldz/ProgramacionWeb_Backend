using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web_24BM.Models;
using Web_24BM.Services;

namespace Web_24BM.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class SendEmailController : ControllerBase
    {
        private readonly IEmailSenderServices _emailSenderServices;

        public SendEmailController(IEmailSenderServices emailSenderServices)
        {
            _emailSenderServices = emailSenderServices;
        }
        [HttpPost]
        [Route("SendData")]
        public IActionResult Send([FromBody] MensajeViewModel model)
        {
            var result = _emailSenderServices.SendEmailWithData(model);

            if (result) {
                return Ok(model);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
