using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using backend.Models;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartamentoController : Controller
    {
        private readonly pruebaContext _context;

        public DepartamentoController(pruebaContext context)
        {
            _context = context;
        }

        // GET: DepartamentoController
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Departamento>>> Get()
        {
            try {
                var obj = await _context.Departamentos.ToListAsync();
                return Ok(obj);
            } catch { 
                return BadRequest("error en la solicitud");
            }
            
        }
    }
}
