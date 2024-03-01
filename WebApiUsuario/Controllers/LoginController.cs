using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApiUsuario.Models;
using WebApiUsuario.constants;

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
        public IActionResult Login(LoginUser loginUser){
            var user = Authentication(loginUser);
            if (user != null){
                //Token
                var token = Generate(user);
                return Ok("Usuario Logueado");
            }
            return NotFound("Usuario no encontrado");
        }

        public Usuario Authentication(LoginUser loginUser){
            var currentUser = UserConstants.users.FirstOrDefault(x=>x.username.ToLower() == loginUser.username.ToLower()
            && x.password == loginUser.password);

            if (currentUser != null){
                    return currentUser;
            }

            return null;
        }

        private string Generate(Usuario user){
           
            var securityKey = new SymmetricSecuritykey(Encoding.UTF8.GetBytes(_config["jwt:Key"]));
            var credentials = new SigningCredentials(securityKey,SecurityAlgorithms.HmacSha256);
             //crear claims
             var claims = new[]  
             {           new claim(claimTypes.nameIdentifier,user.username);
              new claim(claimTypes.email,user.email);
               new claim(claimTypes.role,user.rol);
                new claim(claimTypes.givename,user.name);                
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