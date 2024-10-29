using System.ComponentModel.DataAnnotations;

namespace Guerron_Elizabeth_EXAMENPROGRESO.Models
{
    public class EGuerron
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public float Altura { get; set; }
        [MaxLength(20)]       
        public string Nombre { get; set; }

        [EmailAddress]
        public string Correo { get; set; }

        public bool ClienteAntiguo { get; set; }

        [DataType(DataType.Date)]
        public DateTime Pedido { get; set; }



    }
}
