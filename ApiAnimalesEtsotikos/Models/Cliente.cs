using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiAnimalesEtsotikos.Models
{
    public class Cliente
    {
        [Key]
        public int Id { get; set; }
        public int Cedula { get; set; }
        [Required]
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        
    }
}
