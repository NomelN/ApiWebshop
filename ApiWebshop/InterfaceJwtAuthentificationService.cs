using ApiWebshop.Models;
using System.Security.Claims;

namespace ApiWebshop
{
    public interface InterfaceJwtAuthentificationService
    {
        Utilisateur Authenticate(string email, string password);
        string GenerateToken(string secret, List<Claim> claims);
    }
}
