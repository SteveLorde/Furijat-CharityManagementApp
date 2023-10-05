using Auth0.AuthenticationApi;
using Auth0.AuthenticationApi.Models;
using System.Net.Http;
using BackEndAPI.Data;
using BackEndAPI.Data.Models;
using BackEndAPI.Services.Authentication.Models;
using Nest;

namespace BackEndAPI.Services.Authentication;

class Authentication : IAuthentication
{
    //variables & Injections
    //---------
    
    private IPasswordHash _passwordservice;
    private DataContext _db;
    AuthenticationApiClient client = new AuthenticationApiClient(new Uri("dev-274rp2wmih7hfjup.eu.auth0.com"));
    private HttpClient httpclient = new HttpClient();

    public Authentication(IPasswordHash passwordservice, DataContext db)
    {
        
        _passwordservice = passwordservice;
        _db = db;
    }

    
    public async Task<AccessTokenResponse> Login(UserSign userSign)
    {
        var tokenrequest = new ResourceOwnerTokenRequest()
        {
            Username = userSign.username,
            Password = userSign.password,
            ClientId = userSign.clientId,
        };

        var token = await this.client.GetTokenAsync(tokenrequest);

        return token;
    }

    public void LocalLogin(UserSign userSign)
    {
        //IMPLEMENT GETTING USER HASHED PASSWORD FROM DATABASE O
        var hashedpasswordtocheck = _passwordservice.HashPassword(userSign.password);
        //var usertologin = _db.Users.FirstOrDefault(x => x.username == userSign.username);
    }

    public void LocalRegister(UserSign userSign)
    {
        throw new NotImplementedException();
    }

    public void LocalLogout()
    {
        throw new NotImplementedException();
    }

}
