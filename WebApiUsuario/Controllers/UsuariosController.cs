using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using WebApiUsuario.Models;
using WebApiUsuario.Data;

namespace WebApiUsuario.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuariosController : ControllerBase
    {
      
        private readonly ILogger<UsuariosController> _logger;
        private readonly DataContext _context;

        public UsuariosController(ILogger<UsuariosController> logger, DataContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet (Name = "GetUsuarios") ]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuarios(){
            return await _context.Usuarios.ToListAsync();
        }

        [HttpGet ("{id}",Name = "GetUsuario") ]
        public async Task<ActionResult<Usuario>> GetUsuario(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);

            if(usuario == null){
                return NotFound();
            }

            return usuario;
        }

        [HttpPost]
        public async Task<ActionResult<Usuario>> Post(Usuario usu){
            _context.Usuarios.Add(usu);
            await _context.SaveChangesAsync();

            return new CreatedAtRouteResult("GetUsuario", new {id = usu.id}, usu);
        }

        [HttpPut("{id}")]
        public async Task <ActionResult> Put(int id, Usuario usu)
        {
            
            if (id != usu.id){
                return BadRequest();
            }

            _context.Entry(usu).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}