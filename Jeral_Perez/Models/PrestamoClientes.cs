using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jeral_Perez.Models
{
    public class PrestamoClientes
    {
        public string Cliente { get; set; }
        public decimal Monto { get; set; }
        public int Interes { get; set; }
        public int Plazo { get; set; }
        public decimal Saldo { get; set; }
    }
}
