using Auth0.AuthenticationApi.Models;
using BackEndAPI.Data.Models;
using BackEndAPI.Services.Authentication.Models;

namespace BackEndAPI.Services.Authentication;

public interface IAuthentication
{
    public Task<bool> LocalLogin(LoginModel loginrequest);
    public Task<bool> LocalRegister(RegisterModel usertoregister);
}