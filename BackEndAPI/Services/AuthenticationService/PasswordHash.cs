using System.Security.Cryptography;
using System.Text;

namespace BackEndAPI.Services.Authentication;

public class PasswordHash : IPasswordHash
{
    public string HashPassword(string password)
    {
        SHA256 sha256 = SHA256.Create();
        byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
        byte[] hashBytes = sha256.ComputeHash(passwordBytes);
        string hash = BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
        return hash;
    }

    public bool VerifyPassword(string password, string hashedPassword)
    {
        string hashedInput = HashPassword(password);
        if (StringComparer.OrdinalIgnoreCase.Compare(hashedInput, hashedPassword) == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
        
    }
    
}