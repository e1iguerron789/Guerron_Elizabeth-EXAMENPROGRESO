﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Guerron_Elizabeth_EXAMENPROGRESO.Models
{
    public class EGuerron
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public float Sueldo { get; set; }
        [MaxLength(20)]
        [Required]
        public string Nombre { get; set; }

        [EmailAddress]
        [Required]
        public string Correo { get; set; }

        public bool ClienteAntiguo { get; set; }

        [DataType(DataType.Date)]
        public DateTime Pedido { get; set; }

        public Celular Celular { get; set; }
        [ForeignKey("Celular")]
        public int IdCelular { get; set; }



    }
}
