using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using  WebApiUsuario.Models;

namespace WebApiUsuario.constants
{
    public class UserConstants
    {
        public static List<Usuario> users = new List<Usuario>(){
            new Usuario(){ 
                username = "jPerez", password = "admin123", rol ="Administrador",
                email = "jperez@hotmail.com", name = "Juan"
            },
            new Usuario(){
                username = "aRafael", password = "admin123", rol ="Vendedor",
                email = "arafael@hotmail.com", name = "Alejandro"
            }
        };        
    }
}