using System.Threading.Tasks;

namespace BackEndAPI.Services.EmailService
{
    public interface IMailService
    {
        Task SendEmailAsync(MailRequestModel mailRequestModel);
    }
}
