using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Auth0.AspNetCore.Authentication;

namespace BackEndAPI.Controllers;

[ApiController]
[Route("Authentication")]
public class AuthenticationController : Controller
{
    //Variables & Injections
    //----------------------
    
    
    //Endpoints
    //-----------------
    
    // Login using Auth0
    [HttpPost("Login")]
    public async Task Login()
    {
        var authenticationprops = new LoginAuthenticationPropertiesBuilder().Build();
        await HttpContext.ChallengeAsync(Auth0Constants.AuthenticationScheme, authenticationprops);
    }
    
    [HttpGet("Register")]
    public async Task Register()
    {
        var authenticationprops = new LoginAuthenticationPropertiesBuilder().Build();
        await HttpContext.ChallengeAsync(Auth0Constants.AuthenticationScheme, authenticationprops);
    }
    
    [HttpGet("Logout")]
    public async Task Logout()
    {
        var authenticationprops = new LoginAuthenticationPropertiesBuilder().Build();
        await HttpContext.ChallengeAsync(Auth0Constants.AuthenticationScheme, authenticationprops);
    }

}