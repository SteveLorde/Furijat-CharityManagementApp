using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Auth0.AspNetCore.Authentication;
using Auth0.AuthenticationApi.Models;
using BackEndAPI.Services.Authentication;
using BackEndAPI.Services.Authentication.Models;

namespace BackEndAPI.Controllers;

[ApiController]
[Route("Authentication")]
public class AuthenticationController : Controller
{
    //Variables & Injections
    //----------------------
    private IAuthentication _authservice;

    public AuthenticationController(IAuthentication authservice)
    {
        _authservice = authservice;
    }
    
    //Endpoints
    //-----------------
    
    // Login using Auth0
    [HttpPost("Login")]
    public async Task<Task<AccessTokenResponse>> Login(UserSign usersign)
    {
        var token = _authservice.Login(usersign);

        return token;
    }
    
    [HttpPost("LocalLogin")]
    public async Task LocalLogin(UserSign userSign)
    {
        _authservice.LocalLogin(userSign);
    }
    
    [HttpGet("Register")]
    public async Task Register()
    {
        
    }
    
    [HttpGet("Logout")]
    public async Task Logout()
    {
        var authenticationprops = new LoginAuthenticationPropertiesBuilder().Build();
        await HttpContext.ChallengeAsync(Auth0Constants.AuthenticationScheme, authenticationprops);
    }

}