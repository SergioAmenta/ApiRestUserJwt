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
using Microsoft.AspNetCore.Http;

namespace WebApiUsuario.Service.JwtToken
{
    public class JwtTokenService : IJwtTokenService
    {

        private readonly IConfiguration _config;
         private readonly IHttpContextAccessor _httpContextAccessor;



        public JwtTokenService (IConfiguration config, IHttpContextAccessor httpContextAccessor)
        {
            _config = config;
            _httpContextAccessor = httpContextAccessor;
        }


        public string Generate(Usuario user)
        {
           
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
    
        //decodificar el token
        public Usuario GetCurrentUser()
        {
            var identity = _httpContextAccessor.HttpContext.User.Identity as ClaimsIdentity;
            if (identity != null){
                var userClaims = identity.Claims;

                return new Usuario
                {
                    username = userClaims.FirstOrDefault(o=>o.Type == ClaimTypes.NameIdentifier)?.Value,                   
                    rol = userClaims.FirstOrDefault(o=>o.Type == ClaimTypes.Role)?.Value,
                    email = userClaims.FirstOrDefault(o=>o.Type == ClaimTypes.Email)?.Value,

                };
            }
            return null;
        }
    }
}