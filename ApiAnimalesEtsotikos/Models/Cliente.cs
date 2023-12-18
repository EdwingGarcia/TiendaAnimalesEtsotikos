using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiAnimalesEtsotikos.Models
{
    public class Cliente
    {
        [Key]
        public string Cedula { get; set; }
        [Required]
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Password { get; set; }
       public Boolean Adm {  get; set; }
    }
}