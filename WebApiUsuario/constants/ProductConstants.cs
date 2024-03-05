using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiUsuario.Models;


namespace WebApiUsuario.constants
{
    public class ProductConstants
    {
         public static List<ProductModel> Products = new List<ProductModel>()
        {
            new ProductModel() { Name = "Coca Cola", Description = "Bebida con gas" },
            new ProductModel() { Name = "Agua Villavicencio", Description = "Agua mineral de 2L" },
        };
    }
}