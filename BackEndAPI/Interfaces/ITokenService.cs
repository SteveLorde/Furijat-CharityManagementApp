using BackEndAPI.Data.Entites;
using BackEndAPI.Models;

namespace BackEndAPI.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(User user);
        string CreateToken(Creditor creditor);
    }
}
