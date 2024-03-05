using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiUsuario.Models;

namespace WebApiUsuario.constants
{
    public class EmployeeConstants
    {
        public static List<EmployeeModel> Employees = new List<EmployeeModel>()
        {
            new EmployeeModel() {FirstName = "Tomas", LastName = "Aliaga", Email = "taliaga@gmail.com" },
            new EmployeeModel() {FirstName = "Marcos", LastName = "Gonzalez", Email = "mgonzalez@gmail.com" },
        };
    }
}