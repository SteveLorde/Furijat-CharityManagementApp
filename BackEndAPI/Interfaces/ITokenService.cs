using BackEndAPI.Models;

namespace BackEndAPI.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(User user);
    }
}
