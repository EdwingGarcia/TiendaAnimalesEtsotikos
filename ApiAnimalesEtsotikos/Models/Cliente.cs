using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiAnimalesEtsotikos.Models
{
    public class Cliente
    {
        [Key]
        public int Cedula { get; set; }
        [Required]
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Password { get; set; }
       // public  int? AnimalComprado { get; set; } //Id animal
    }
}