using ApiAnimalesEtsotikos.Data;
using ApiAnimalesEtsotikos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiAnimalesEtsotikos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {

        private readonly ApplicationDBContext _db;
        public ClienteController(ApplicationDBContext db)
        {
            _db = db;
        }






        // GET: api/<ClienteController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<Cliente> clientes = await _db.Cliente.ToListAsync();
            return Ok(clientes);
        }

        // GET api/<ClienteController>/5
        [HttpGet("{Cedula}")]
        public async Task<IActionResult> Get(int Cedula)
        {
            Cliente cliente = await _db.Cliente.FirstOrDefaultAsync(x => x.Cedula == Cedula);
            if (cliente != null)
            {
                return Ok(cliente);
            }
            return BadRequest();
        }

        // POST api/<ClienteController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Cliente cliente)
        {
            Cliente cliente1 = await _db.Cliente.FirstOrDefaultAsync(x => x.Cedula == cliente.Cedula);
            if (cliente1 == null && cliente != null)
            {
                await _db.Cliente.AddAsync(cliente);
                await _db.SaveChangesAsync();
                return Ok();
            }
            return BadRequest("El objeto no existe");
        }


        // PUT api/<AnimalController>/5
        [HttpPut("{Cedula}")]
        public async Task<IActionResult> Put(int Cedula, [FromBody] Cliente cliente)
        {
            Cliente cliente1 = await _db.Cliente.FirstOrDefaultAsync(x => x.Cedula == cliente.Cedula);
            if (cliente1 != null)
            {
                cliente1.Nombre = cliente.Nombre != null ? cliente.Nombre : cliente1.Nombre;
                cliente1.Direccion = cliente.Direccion != null ? cliente.Direccion : cliente1.Direccion;


                _db.Cliente.Update(cliente1);
                await _db.SaveChangesAsync();
                return Ok(cliente1);
            }
            return BadRequest();

        }

        // DELETE api/<ClienteController>/5
        [HttpDelete("{Cedula}")]
        public async Task<IActionResult> Delete(int Cedula)
        {
            Cliente cliente = await _db.Cliente.FirstOrDefaultAsync(x => x.Cedula == Cedula);
            if (cliente != null)
            {
                _db.Cliente.Remove(cliente);
                await _db.SaveChangesAsync();
                return NoContent();
            }
            return BadRequest();

        }

    }
}