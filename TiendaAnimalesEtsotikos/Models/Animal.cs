using System.ComponentModel.DataAnnotations;

namespace TiendaAnimalesEtsotikos.Models
{
    public class Animal
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set;}
        public string NombreCientifico {  get; set; }
        public string PaisOrigen {  get; set; }
        public float Altura { get; set; }
        public float Peso { get; set; }
        public int Status { get; set; } //  NoComprado=0 Comprado=1 Internado=2
        public string Enfermedad { get; set; }
        public string? Propietario { get; set; }//Cedula Propietario
        public string Img { get; set; }



    }
}
