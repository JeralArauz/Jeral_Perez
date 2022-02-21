using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jeral_Perez.Models
{
    public class PagosClientes
    {
        public PagosClientes()
        {
            Clientes = new List<Cliente>();
            Prestamos = new List<Prestamo>();
            Pagos = new List<Pagos>();
        }
        public List<Cliente> Clientes { get; set; }

        public List<Pagos> Pagos { get; set; }
        public List<Prestamo> Prestamos { get; set; }
    }
}
