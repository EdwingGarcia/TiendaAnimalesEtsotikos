using ApiAnimalesEtsotikos.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiAnimalesEtsotikos.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options) { }
        public DbSet<Animal> Animal { get; set; }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Veterinario> Veterinario { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


        }
    }
}