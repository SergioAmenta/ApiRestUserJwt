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
    public class CountryController : ControllerBase
    {
         [HttpGet]
        public IActionResult Get()
        {
            var listCountry = CountryConstants.Countrys;

            return Ok(listCountry);
        }
    }
}