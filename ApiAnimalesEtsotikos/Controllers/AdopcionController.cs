using ApiAnimalesEtsotikos.Data;
using ApiAnimalesEtsotikos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiAnimalesEtsotikos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdopcionController : ControllerBase
    {

        private readonly ApplicationDBContext _db;
        public AdopcionController(ApplicationDBContext db)
        {
            _db = db;
        }

       
        /*
        // PUT api/<AnimalController>/5
        [HttpPut("{Id}")]
        public async Task<IActionResult> Put(int Id, [FromBody] Animal animal)
        {
            Animal animal1 = await _db.Animal.FirstOrDefaultAsync(x => x.Id == animal.Id);
            if (animal1 != null)
            {
                animal1.Propietario = animal.Propietario != null ? animal.Propietario : animal1.Propietario;
      
                Cliente cliente = await _db.Cliente.FirstOrDefaultAsync(x => x.Cedula == animal1.Propietario);
                cliente.AnimalComprado.Add((int)animal1.Propietario);
                _db.Animal.Update(animal1);
                _db.Cliente.Update(cliente); ; ;
                await _db.SaveChangesAsync();
                return Ok(animal1);
            }
            return BadRequest();

        }
        */






















    }
}
