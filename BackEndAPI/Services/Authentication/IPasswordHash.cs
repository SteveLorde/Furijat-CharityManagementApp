namespace BackEndAPI.Services.Authentication;

public interface IPasswordHash
{
    public string HashPassword(string password);
    public bool VerifyPassword(string password, string hashedPassword);
    
}