using Jeral_Perez.Data;
using Jeral_Perez.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Jeral_Perez.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EchelonController : ControllerBase
    {

        private readonly MyDbContext _context;

        public EchelonController(MyDbContext context)
        {
            _context = context;
        }

        // GET: api/<EchelonController>
        [HttpGet]
        public IEnumerable<Cliente> Get()
        {

            IEnumerable<Cliente> clientes = _context.Clientes.ToList();

            return clientes;
        }

        // GET api/<EchelonController>/5
        [HttpGet("{id}")]
        //public Cliente Get(int id)
        //{

        //    Cliente  clientes = _context.Clientes.Where(a => a.IdCliente == id).FirstOrDefault();

        //    if(clientes == null)
        //        return new Cliente();

        //    return clientes;
        //}
        public Prestamo Get(int id)
        {

            Prestamo prestamo = _context.Prestamo.Where(a => a.IdPrestamo == id).FirstOrDefault();

            if (prestamo == null)
                return new Prestamo();

            return prestamo;
        }

        // POST api/<EchelonController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<EchelonController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<EchelonController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
