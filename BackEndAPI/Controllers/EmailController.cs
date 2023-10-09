using BackEndAPI.Services.EmailService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace BackEndAPI.Controllers
{

    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly IMailService mailService;
        public EmailController(IMailService mailService)
        {
            this.mailService = mailService;
        }
        
        [Route("api/email")]
        [HttpPost]
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
