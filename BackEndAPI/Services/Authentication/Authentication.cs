using Auth0.AuthenticationApi;
using Auth0.AuthenticationApi.Models;
using System.Net.Http;
using BackEndAPI.Services.Authentication.Models;
using Nest;

namespace BackEndAPI.Services.Authentication;

class Authentication : IAuthentication
{
    //variables
    //---------
    AuthenticationApiClient client = new AuthenticationApiClient(new Uri("dev-274rp2wmih7hfjup.eu.auth0.com"));
    private HttpClient httpclient = new HttpClient();
    
    public async Task<AccessTokenResponse> Login(UserSign userSign)
    {
        var tokenrequest = new ResourceOwnerTokenRequest()
        {
            Username = userSign.Username,
            Password = userSign.Password,
            ClientId = userSign.ClientId,
        };

        var token = await this.client.GetTokenAsync(tokenrequest);

        return token;
    }

    public async Task<HttpResponseMessage> LoginHttp(UserSign userSign)
    {
        var responsetoken = await httpclient.GetAsync("https://dev-274rp2wmih7hfjup.eu.auth0.com/authorize?response_type=code|token&client_id=YWVDWQf8qlp9xmwXHfUh7rnnp85dKZtL&redirect_uri=undefined&state=null");
        return responsetoken;
    }

    public void Register()
    {
        
    }

    public void Logout()
    {
        
    }
}
