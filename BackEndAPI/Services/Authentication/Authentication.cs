using Auth0.AuthenticationApi;

namespace BackEndAPI.Services.Authentication;

class Authentication : IAuthentication
{
    //variables
    //---------
    AuthenticationApiClient client = new AuthenticationApiClient(new Uri("https://YOUR_AUTH0_DOMAIN"));


    public void Login()
    {
        this.client.GetTokenAsync();
    }

    public void Register()
    {
        
    }

    public void Logout()
    {
        
    }
}
