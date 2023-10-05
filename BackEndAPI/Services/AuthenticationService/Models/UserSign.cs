namespace BackEndAPI.Services.Authentication.Models;

public class UserSign
{
    public string username { get; set; }
    public string password { get; set; }
    public string email { get; set; }
    public string? clientId { get; set; }
}