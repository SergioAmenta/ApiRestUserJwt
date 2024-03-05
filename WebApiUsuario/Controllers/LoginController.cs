using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApiUsuario.Models;
using WebApiUsuario.constants;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

namespace WebApiUsuario.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly IConfiguration _config;

        public LoginController (IConfiguration config){
            _config = config;
        }


        [HttpPost] 
        public IActionResult Login(LoginUser loginUser)
        {
            
            var user = Authentication(loginUser);
            if (user != null){
                //Token
                var token = Generate(user);
                return Ok(token);
            }
            return NotFound("Usuario no encontrado");
        }

        
        private Usuario Authentication(LoginUser loginUser)
        {
            var currentUser = UserConstants.users.FirstOrDefault(x=>x.username.ToLower() == loginUser.username.ToLower()
            && x.password == loginUser.password);

            if (currentUser != null){
                    return currentUser;
            }

            return null;
        }

        private string Generate(Usuario user){
           
            var securityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_config.GetValue<string>("jwt:Key")));
            var credentials = new SigningCredentials(securityKey,SecurityAlgorithms.HmacSha256);
             //crear claims
             var claims = new[]  
             {           
                new Claim(ClaimTypes.NameIdentifier,user.username),
                new Claim(ClaimTypes.Email,user.email),
                new Claim(ClaimTypes.Role,user.rol),
                //new Claim(ClaimTypes.GiveName,user.name)                
             };
            //crear token

           var token = new JwtSecurityToken(
                _config["Jwt:Issuer"],
                _config["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(60),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}