using backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly pruebaContext _context;

        public UserController(pruebaContext context)
        {
            _context = context;
        }
        // GET: UserController
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> Get()
        {
            try
            {
                var obj = await _context.Users.ToListAsync();
                return Ok(obj);
            }
            catch
            {
                return BadRequest("error en la solicitud");
            }

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetById(int id)
        {
            var obj = await _context.Users.FindAsync(id);

            if (obj == null)
            {
                return NotFound();
            }

            return Ok(obj);

        }

        [HttpPost]
        public async Task<ActionResult<UserDto>> create(UserDto user)
        {
            var newUser = new User
            {
                Usuario = user.Usuario,
                PrimerNombre = user.PrimerNombre,
                SegundoNombre = user.SegundoNombre,
                PrimerApellido = user.PrimerApellido,
                SegundoApellido = user.SegundoApellido,
                Email = user.Email,
                IdDepartamento = user.IdDepartamento,
                IdCargo = user.IdCargo,
            };
            _context.Users.Add(newUser);
            await _context.SaveChangesAsync();

            return Ok(user);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> update(int id, UserDto user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }

            var obj = await _context.Users.FindAsync(id);
            if (obj == null)
            {
                return NotFound();
            }

            obj.Usuario = user.Usuario;
            obj.PrimerNombre = user.PrimerNombre;
            obj.SegundoNombre = user.SegundoNombre;
            obj.PrimerApellido = user.PrimerApellido;
            obj.SegundoApellido = user.SegundoApellido;
            obj.Email = user.Email;
            obj.IdDepartamento = user.IdDepartamento;
            obj.IdCargo = user.IdCargo;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch 
            {
                return NotFound();
            }

            return Ok(obj);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodoItem(int id)
        {
            var obj = await _context.Users.FindAsync(id);

            if (obj == null)
            {
                return NotFound();
            }

            _context.Users.Remove(obj);
            await _context.SaveChangesAsync();

            return Ok("Registro eliminado");
        }
    }
}
