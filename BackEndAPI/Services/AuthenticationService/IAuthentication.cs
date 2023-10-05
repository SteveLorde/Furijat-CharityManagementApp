using Auth0.AuthenticationApi.Models;
using BackEndAPI.Data.Models;
using BackEndAPI.Services.Authentication.Models;

namespace BackEndAPI.Services.Authentication;

public interface IAuthentication
{
    public Task<AccessTokenResponse> Login(UserSign userSign);
    public void LocalLogin(UserSign userSign);
    public void LocalRegister(UserSign userSign);
    public void LocalLogout();
}