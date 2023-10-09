using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using BackEndAPI.Data.Models;
using BackEndAPI.Services.Authentication;
using BackEndAPI.Services.Authentication.Models;


namespace BackEndAPI.Controllers;

[Route("api/Authentication")]
[ApiController]
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
    

    [HttpPost("LocalLogin")]
    public async Task<bool> LocalLogin(LoginModel loginmodel)
    {
        return await _authservice.LocalLogin(loginmodel);
    }
    
    [HttpPost("LocalRegister")]
    public async Task<bool> LocalRegister(RegisterModel registerModel)
    {
        return await _authservice.LocalRegister(registerModel);
    }
}