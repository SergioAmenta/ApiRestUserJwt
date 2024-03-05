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
    public class ProductController  : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var listProducts = ProductConstants.Products;            
            return Ok(listProducts);
        }
    }
}