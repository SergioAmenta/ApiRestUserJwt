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
using Microsoft.AspNetCore.Authorization;

namespace WebApiUsuario.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController  : ControllerBase
    {
        [HttpGet]
        [Authorize]
        public IActionResult Get()
        {
            var listProducts = ProductConstants.Products;            
            return Ok(listProducts);
        }
    }
}