using AuthenticationAPI.Models;

namespace AuthenticationAPI.Services.Interfaces
{
    public interface IAuthenticationService
    {
        void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt);

        bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt);

        string GenerateJwtToken(User user);

        string GenerateRefreshToken();
    }
}