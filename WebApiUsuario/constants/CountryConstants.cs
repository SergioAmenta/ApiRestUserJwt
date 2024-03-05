using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiUsuario.Models;

namespace WebApiUsuario.constants
{
    public class CountryConstants
    {
         public static List<CountryModel> Countrys = new List<CountryModel>()
        {
            new CountryModel() { Name = "Argentina"},
            new CountryModel() { Name = "Peru"},
            new CountryModel() { Name = "Mexico"},
        };
    }
}