using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TiendaAnimalesEtsotikos.Models
{
    public class Cliente
    {
        public string Password { get; set; }
        [Key]
        public string Cedula { get; set; }
        [Required]
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public int? AnimalComprado { get; set; } //Id animal
    }
}
