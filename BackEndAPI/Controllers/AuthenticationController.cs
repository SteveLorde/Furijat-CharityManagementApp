using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Auth0.AspNetCore.Authentication;
using Auth0.AuthenticationApi.Models;
using BackEndAPI.Data.Models;
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
    public async Task<Task<bool>> LocalLogin(LoginModel loginmodel)
    {
        return _authservice.LocalLogin(loginmodel);
    }
    
    [HttpPost("LocalLogin")]
    public async Task<Task<bool>> LocalRegister(RegisterModel registerModel)
    {
        return _authservice.LocalRegister(registerModel);
    }
}