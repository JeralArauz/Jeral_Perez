using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jeral_Perez.Models
{
    public class PrestamoClientes
    {
        public PrestamoClientes()
        {
            Clientes = new List<Cliente>();
            Prestamos = new List<Prestamo>();
        }
        public List<Cliente> Clientes { get; set; }

        public List<Prestamo> Prestamos { get; set; }
    }
}
