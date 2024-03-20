using AuthenticationMS.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AuthenticationMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors]
    public class AuthController : ControllerBase
    {
        private readonly AuthContext _context;
        public AuthController(AuthContext context)
        {
            _context = context;
        }

        [HttpPost("[action]")]
        public async Task<ActionResult<UserModel>> newUser(UserModel userModel)
        {
            _context.UserModels.Add(userModel);
            await _context.SaveChangesAsync();

            return Ok(userModel);
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody]UserModel userM)
        {
            string Username = userM.UserName;
            string Password = userM.Password;
            var user = await _context.UserModels.FindAsync(Username);
            if (user == null)
                return Ok(new { message = "Invalid Username"});
            if(user.Password == Password)
            {
                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("somethingyouwantwhichissecurewillworkk"));
                var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Role,user.Role),
                    new Claim(ClaimTypes.Name,user.UserName)
                };
                var token = new JwtSecurityToken(
                    issuer: "mySystem",
                    audience: "myUsers",
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(30),
                    signingCredentials: credentials
                );
                var newtoken = "";
                if(user.Role=="Manager")
                    newtoken = new JwtSecurityTokenHandler().WriteToken(token);
                else if(user.Role == "Customer")
                    newtoken = new JwtSecurityTokenHandler().WriteToken(token);
                else if (user.Role == "Executive")
                    newtoken = new JwtSecurityTokenHandler().WriteToken(token);
                return Ok(new { Token = newtoken, message = user.Role, name = Username, password = Password});
            }
            return Ok(new { message = "Invalid Password" });
        }
    }
}
