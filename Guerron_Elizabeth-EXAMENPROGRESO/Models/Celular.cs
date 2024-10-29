using System.ComponentModel.DataAnnotations;

namespace Guerron_Elizabeth_EXAMENPROGRESO.Models
{
    public class Celular
    {
        [Key]
        public int Id { get; set; }
        [StringLength(20)]
        public string Modelo { get; set; }

        [Range(2000, 2024)]
        public int Amo { get; set; }
        public float Precio { get; set; }

        
    }
}
