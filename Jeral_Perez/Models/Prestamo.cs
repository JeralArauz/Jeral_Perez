﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Jeral_Perez.Models
{
    public class Prestamo
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int IdCliente { get; set; }

        [ForeignKey("IdCliente")]
        public Cliente Cliente { get; set; }

        [Required]
        [Column(TypeName = "decimal(12,2)")]
        public decimal Monto { get; set; }

        [Required]
        public int Plazo { get; set; }

        [Column(TypeName = "decimal(12,2)")]
        public decimal Saldo { get; set; }

        public string UserReg { get; set; }
        public DateTime FechaReg {get; set;}
    }
}
