using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Jeral_Perez.Models
{
    public class Pagos
    {
        [Key]
        public int IdPago { get; set; }

        [Required]
        public int IdPrestamo { get; set; }
        [ForeignKey("IdPrestamo")]
        public Prestamo Prestamo  { get; set; }

        [Column(TypeName = "decimal(12,2)")]
        public decimal MontoPagado { get; set; }

        [Column(TypeName = "decimal(12,2)")]
        public decimal Saldo { get; set; }
        public DateTime FechaPago { get; set; }

        public string UserReg { get; set; }
    }
}
