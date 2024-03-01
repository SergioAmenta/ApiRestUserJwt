using Microsoft.EntityFrameworkCore;
using WebApiUsuario.Models;

namespace WebApiUsuario.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
        :base(options){
        }

        public DbSet<Usuario> Usuarios{get;set;}
    }
}