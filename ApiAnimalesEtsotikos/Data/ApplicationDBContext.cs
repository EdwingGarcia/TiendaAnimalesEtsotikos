using ApiAnimalesEtsotikos.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiAnimalesEtsotikos.Data
{
    public class ApplicationDBContext:DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options):base (options) { }
        public DbSet<Animal> Animal { get; set; }
        public DbSet<Cliente> Cliente { get; set; } 
        public DbSet<Veterinario> Veterinario { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Animal>().HasData(

                new Animal()
                {
                    Id = 2,
                    Nombre = "perro",
                    NombreCientifico = "pipi",
                    PaisOrigen = "Norteamérica del Sur",
                    Altura = 2.4f,
                    Peso = 22,
                    Status = 1,
                    Enfermedad = "tos",
                    Propietario = "",
                    Img = "https://as01.epimg.net/diarioas/imagenes/2022/05/29/actualidad/1653826510_995351_1653826595_noticia_normal_recorte1.jpg"
                }
            ); 

            modelBuilder.Entity<Cliente>().HasData(
                new Cliente()
                {

                    Cedula ="123",
                    Nombre = "Edwing",
                    Direccion = "Conocoto",
                    Password = "123",

                   
                }                
            );



            modelBuilder.Entity<Veterinario>().HasData(
              new Veterinario()
              {
                  NombreVeterinario = "Patitas del Saber",
                  DireccionVeterinario = "cuba",
                  TelefonoVeterinario = 00000
              }
            );

        }
    }
}
