using ApiAnimalesEtsotikos.Data;
using ApiAnimalesEtsotikos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiAnimalesEtsotikos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalController : ControllerBase
    {
        private readonly ApplicationDBContext _db;
        public AnimalController(ApplicationDBContext db)
        {
            _db = db;
        }

        // GET: api/<AnimalController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
           List<Animal> animals= await _db.Animal.ToListAsync();
            return Ok(animals);
        }





        // GET api/<AnimalController>/5
        [HttpGet("{Id}")]
        public async Task<IActionResult> Get(int Id)
        {
           Animal animal= await _db.Animal.FirstOrDefaultAsync(x=>x.Id==Id);
            if (animal != null)
            {
                return Ok(animal);
            }
            return BadRequest();
        }





        // POST api/<AnimalController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Animal animal)
        {
            Animal animal1= await _db.Animal.FirstOrDefaultAsync(x=>x.Id==animal.Id);
            if (animal1 == null && animal!=null) {
                await _db.Animal.AddAsync(animal);
                await _db.SaveChangesAsync();
                return Ok();
            }
            return BadRequest("El objeto no existe");
        }





        // PUT api/<AnimalController>/5
        [HttpPut("{Id}")]
        public async Task<IActionResult> Put(int Id, [FromBody] Animal animal)
        {
            Animal animal1=await _db.Animal.FirstOrDefaultAsync(x=>x.Id == animal.Id);
            if(animal1 != null)
            {
                animal1.Nombre= animal.Nombre != null ? animal.Nombre : animal1.Nombre;
                animal1.NombreCientifico= animal.NombreCientifico != null ? animal.NombreCientifico : animal1.NombreCientifico;
                animal1.PaisOrigen= animal.PaisOrigen != null ? animal.PaisOrigen : animal1.PaisOrigen;
                animal1.Altura= animal.Altura != null ? animal.Altura : animal1.Altura;
                animal1.Peso = animal.Peso != null ? animal.Peso : animal1.Peso;
                animal1.Status= animal.Status != null ? animal.Status : animal1.Status;
                animal1.Enfermedad= animal.Enfermedad != null ? animal.Enfermedad : animal1.Enfermedad;
                animal1.CedulaCliente= animal.CedulaCliente != null ? animal.CedulaCliente : animal1.CedulaCliente;
                _db.Animal.Update(animal1);
                await _db.SaveChangesAsync();
                return Ok(animal1);
            }
            return BadRequest();

        }





        // DELETE api/<AnimalController>/5
        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(int Id)
        {
            Animal animal=await _db.Animal.FirstOrDefaultAsync(x=>x.Id==Id);
            if (animal != null)
            {
                _db.Animal.Remove(animal);
                await _db.SaveChangesAsync();
                return NoContent();
            }
            return BadRequest();

        }

        [HttpGet("GetAnimalesPorCedula/{CedulaCliente}")]
        public async Task<ActionResult<IEnumerable<Animal>>> GetAnimalesPorCedula(int CedulaCliente)
        {
            var animales = await _db.Animal.Where(a => a.CedulaCliente == CedulaCliente).ToListAsync();

            if (animales == null || animales.Count == 0)
            {
                return NotFound("No se encontraron animales para esta cédula.");
            }

            return Ok(animales);
        }



    }
}
