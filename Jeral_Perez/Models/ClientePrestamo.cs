using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jeral_Perez.Models
{
    public class ClientePrestamo
    {
        public int IdCliente { get; set; }
        public string NombreCliente { get; set; }
        public string Cedula { get; set; }
        public string Direccion { get; set; }
        public decimal TotalDeuda { get; set; }
        public decimal Saldo { get; set; }
    }
}
