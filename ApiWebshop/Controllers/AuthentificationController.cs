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
        public IActionResult Login([FromBody] ConnexionModel model)
        { 
            throw new NotImplementedException();
        }
            
    }
}
