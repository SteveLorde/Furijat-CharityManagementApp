namespace BackEndAPI.Services.Authentication;

public interface IAuthentication
{
    public void Login();
    public void Register();
    public void Logout();
}