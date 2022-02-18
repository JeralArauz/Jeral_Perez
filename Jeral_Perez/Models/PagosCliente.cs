using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jeral_Perez.Models
{
    public class PagosCliente
    {
        public string Cliente { get; set; }
        public decimal TotalDeuda { get; set; }

        public decimal MontoPagado { get; set; }
        public string FechaPago { get; set; }
        public decimal Saldo { get; set; }
    }
}
