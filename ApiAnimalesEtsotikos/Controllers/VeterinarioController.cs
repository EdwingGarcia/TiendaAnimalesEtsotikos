using ApiAnimalesEtsotikos.Data;
using ApiAnimalesEtsotikos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiAnimalesEtsotikos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VeterinarioController : ControllerBase
    {
        private readonly ApplicationDBContext _db;
        public VeterinarioController(ApplicationDBContext db)
        {
            _db = db;
        }

        // GET: api/<AnimalController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<Veterinario> veterinarios = await _db.Veterinario.ToListAsync();
            return Ok(veterinarios);
        }





        // GET api/<AnimalController>/5
        [HttpGet("{NombreVeterinario}")]
        public async Task<IActionResult> Get(string NombreVeterinario)
        {
            Veterinario veterinario = await _db.Veterinario.FirstOrDefaultAsync(x => x.NombreVeterinario == NombreVeterinario);
            if (veterinario != null)
            {
                return Ok(veterinario);
            }
            return BadRequest();
        }





        // POST api/<AnimalController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Veterinario veterinario)
        {
            Veterinario veterinario1 = await _db.Veterinario.FirstOrDefaultAsync(x => x.NombreVeterinario == veterinario.NombreVeterinario);
            if (veterinario1 == null && veterinario != null)
            {
                await _db.Veterinario.AddAsync(veterinario);
                await _db.SaveChangesAsync();
                return Ok();
            }
            return BadRequest("El objeto no existe");
        }





        // PUT api/<AnimalController>/5
        [HttpPut("{NombreVeterinario}")]
        public async Task<IActionResult> Put(string NombreVeterinario, [FromBody] Veterinario veterinario)
        {
            Veterinario veterinario1 = await _db.Veterinario.FirstOrDefaultAsync(x => x.NombreVeterinario == veterinario.NombreVeterinario);
            if (veterinario1 != null)
            {
                veterinario1.NombreVeterinario = veterinario.NombreVeterinario != null ? veterinario.NombreVeterinario : veterinario1.NombreVeterinario;
                veterinario1.DireccionVeterinario = veterinario.DireccionVeterinario != null ? veterinario.DireccionVeterinario : veterinario1.DireccionVeterinario;
                veterinario1.TelefonoVeterinario = veterinario.TelefonoVeterinario != null ? veterinario.TelefonoVeterinario : veterinario1.TelefonoVeterinario;

                _db.Veterinario.Update(veterinario1);
                await _db.SaveChangesAsync();
                return Ok(veterinario1);
            }
            return BadRequest();

        }





        // DELETE api/<AnimalController>/5
        [HttpDelete("{NombreVeterinario}")]
        public async Task<IActionResult> Delete(string NombreVeterinario)
        {
            Veterinario veterinario = await _db.Veterinario.FirstOrDefaultAsync(x => x.NombreVeterinario == NombreVeterinario);
            if (veterinario != null)
            {
                _db.Veterinario.Remove(veterinario);
                await _db.SaveChangesAsync();
                return NoContent();
            }
            return BadRequest();

        }
    }
}
