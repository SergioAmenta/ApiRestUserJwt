using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiUsuario.Models
{
    public class Usuario
    {
        public int id{get;set;}
        public string username{get;set;} = string.Empty;
        public string name {get;set;} = string.Empty;
        public string password {get;set;} = string.Empty;
        public string rol {get;set;} = string.Empty;
        public string email {get;set;} = string.Empty;
        public bool activo {get;set;}
    }
}