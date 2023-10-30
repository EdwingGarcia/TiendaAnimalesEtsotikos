using System.ComponentModel.DataAnnotations;

namespace ApiAnimalesEtsotikos.Models
{
    public class Veterinario
    {
        [Key]
        public string NombreVeterinario { get; set; }
        public string DireccionVeterinario { get; set; }
        public int TelefonoVeterinario { get; set; }



    }
}