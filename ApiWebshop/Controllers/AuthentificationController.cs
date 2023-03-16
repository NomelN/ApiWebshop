using ApiWebshop.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ApiWebshop.Controllers
{
    [Route("api/webshop/[controller]")]
    [ApiController]
    public class AuthentificationController : ControllerBase
    {
        private readonly InterfaceJwtAuthentificationService _jwtAuthentificationService;
        private IConfiguration _config;
        public AuthentificationController(InterfaceJwtAuthentificationService jwtAuthentificationService, IConfiguration config)
        {
            _jwtAuthentificationService = jwtAuthentificationService;
            _config = config;
        }

        [HttpPost]
        [Route("Login")]
        public IActionResult Login([FromBody] ConnexionModel model)
        {
            var utilisateur = _jwtAuthentificationService.Authenticate(model.Email, model.Password);
            if(utilisateur != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Email, utilisateur.Email),
                };
                var token = _jwtAuthentificationService.GenerateToken(_config["Jwt:Key"], claims);
                return Ok(token);
            }
            return Unauthorized();
            
        }
            
    }
}
