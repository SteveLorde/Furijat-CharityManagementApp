using BackEndAPI.Services.EmailService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace BackEndAPI.Controllers
{

    [ApiController]
    [Route("api/email")]
    public class EmailController : ControllerBase
    {
        private readonly IMailService mailService;
        public EmailController(IMailService mailService)
        {
            this.mailService = mailService;
        }

        [HttpPost("Send")]
        public async Task<IActionResult> Send(MailRequestModel requestModel)
        {
            try
            {
                await mailService.SendEmailAsync(requestModel);
                return Ok();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
