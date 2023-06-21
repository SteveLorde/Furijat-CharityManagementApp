using BackEndAPI.Data.Entites;
using BackEndAPI.Models;

namespace BackEndAPI.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(User user);
        string CreateToken(Creditor creditor);
        string CreateToken(Charity charity);
    }
}
