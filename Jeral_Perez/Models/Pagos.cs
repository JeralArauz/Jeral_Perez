using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jeral_Perez.Models
{
    public class Pagos
    {
        public string NombreCompleto { get; set; }
        public string Prestamo { get; set; }
        public int MontoPagado { get; set; }
        public string FechaPago { get; set; }
        public int Saldo { get; set; }
    }
}
