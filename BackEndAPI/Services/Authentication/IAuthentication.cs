using Auth0.AuthenticationApi.Models;
using BackEndAPI.Services.Authentication.Models;

namespace BackEndAPI.Services.Authentication;

public interface IAuthentication
{
    public Task<AccessTokenResponse> Login(UserSign userSign);
    public Task<HttpResponseMessage> LoginHttp(UserSign userSign);
    public void Register();
    public void Logout();
}