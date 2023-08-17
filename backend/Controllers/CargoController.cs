using backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CargoController : Controller
    {
        private readonly pruebaContext _context;

        public CargoController(pruebaContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cargo>>> Get()
        {
            try
            {
                var obj = await _context.Cargos.ToListAsync();
                return Ok(obj);
            }
            catch
            {
                return BadRequest("error en la solicitud");
            }
        }
    }
}
