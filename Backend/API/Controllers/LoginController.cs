using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace interviewbase.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class LoginController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public LoginController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost]
        public ActionResult<LoginResponseDTO> Login(LoginModelDTO model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Please enter username and password");
            }
            
            var key = Encoding.ASCII.GetBytes(_configuration.GetValue<string>("JWTSecret"));
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = new SecurityTokenDescriptor()
            {
                Subject=new ClaimsIdentity(
                    new Claim[]
                    {
                        new Claim(ClaimTypes.Name,model.UserName),
                        new Claim(ClaimTypes.Role,"Admin")
                    }
                    ),
                Expires=DateTime.UtcNow.AddHours(4),
                SigningCredentials=new(new SymmetricSecurityKey(key),SecurityAlgorithms.HmacSha512Signature)
            };
            var tokenh = tokenHandler.CreateToken(token);
            var tokeng=tokenHandler.WriteToken(tokenh);
            LoginResponseDTO res = new LoginResponseDTO();
            res.Token = tokeng;
            res.UserName=model.UserName;
            return Ok(res);
        }
    }
    public class LoginModelDTO
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }

    public class LoginResponseDTO
    {
        public string UserName { get; set; }
        public string Token { get; set; }
    }
}
