using ApiAnimalesEtsotikos.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiAnimalesEtsotikos.Data
{
    public class ApplicationDBContext:DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options):base (options) { }
        public DbSet<Animal> Animal { get; set; }
        public DbSet<Cliente> Cliente { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Animal>().HasData(
                new Animal()
                {
                    Id = 1,
                    Nombre = "Carlos",
                    NombreCientifico = "popo",
                    PaisOrigen = "Sudamérica del Norte",
                    Altura = 6.5f,
                    Peso = 54,
                    Status = 0,
                    Enfermedad = "gonorrea",
                    Propietario = null
                },
                new Animal()
                {
                    Id = 2,
                    Nombre = "Julian",
                    NombreCientifico = "pipi",
                    PaisOrigen = "Norteamérica del Sur",
                    Altura = 2.4f,
                    Peso = 22,
                    Status = 1,
                    Enfermedad = "estudiar derecho",
                    Propietario = null
                }
            );

            modelBuilder.Entity<Cliente>().HasData(
                new Cliente()
                {
                    Cedula = 1723124796,
                    Nombre = "Edwing",
                    Direccion = "Conocoto"
                }
            );
        }
    }
}
