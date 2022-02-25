using System;
using Jeral_Perez.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Jeral_Perez.Data;
using Microsoft.Extensions.Logging;
using System.Linq;

namespace Jeral_Perez.Controllers
{
    public class UNIController : Controller
    {
        private readonly ILogger<UNIController> _logger;
        private readonly MyDbContext _context;


        public UNIController(ILogger<UNIController> logger, MyDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult Clientes()
        {
            List<Cliente> clientes = _context.Clientes.ToList();
            return View(clientes);
        }
        public IActionResult AgregarClientes()
        {
            return View();
        }
        public IActionResult RegistrarClienteNew(Cliente cliente)
        {
            cliente.FechaReg = DateTime.Now;
            cliente.UserReg = "Admin";
            _context.Clientes.Add(cliente);
            _context.SaveChanges();
            return RedirectToAction("Clientes");
        }
        public IActionResult EditarCliente(int IdCliente)
        {
            Cliente cliente = _context.Clientes.Where(c => c.IdCliente == IdCliente).FirstOrDefault();
            return View(cliente);
        }
        public IActionResult ActualizarCliente(Cliente cliente)
        {
            Cliente clienteactual = _context.Clientes
                .Where(a=> a.IdCliente == cliente.IdCliente).FirstOrDefault();

            clienteactual.Nombres = cliente.Nombres;
            clienteactual.Apellidos = cliente.Apellidos;
            clienteactual.Cedula = cliente.Cedula;
            clienteactual.Direccion = cliente.Direccion;
            clienteactual.Telefono = cliente.Telefono;
            clienteactual.Sexo = cliente.Sexo;

            List<Cliente> clientes = _context.Clientes.ToList();

            return View("Clientes", clientes);
        }

        public IActionResult EliminarCliente(int IdCliente)
        {
            List<Prestamo> prestamos = _context.Prestamo.Where(a => a.IdCliente == IdCliente).ToList();
            if(prestamos != null)
            _context.Prestamo.RemoveRange(prestamos);

            Cliente clienteactual = _context.Clientes
                .Where(a => a.IdCliente == IdCliente).FirstOrDefault();
            if(clienteactual != null)
            _context.Remove(clienteactual);

            _context.SaveChanges();

            List<Cliente> clientes = _context.Clientes.ToList();
            return View("Clientes", clientes);
        }
        public IActionResult Prestamos()
        {
            PrestamoClientes Prestamocliente = new PrestamoClientes();
            Prestamocliente.Clientes = _context.Clientes.ToList();
            Prestamocliente.Prestamos = _context.Prestamo.ToList();
            return View(Prestamocliente);
        }
        public IActionResult NuevoPrestamo()
        {
            List<Cliente> clientes = _context.Clientes.ToList();
            return View(clientes);
        }
        public IActionResult AgregarPrestamo(int IdCliente)
        {
            List<Cliente> cliente = _context.Clientes.Where(c => c.IdCliente == IdCliente).ToList();
            return View("NuevoPrestamo",cliente);
        }
        public IActionResult GuardarPrestamo(Prestamo prestamo)
        {
            prestamo.FechaReg = DateTime.Now;
            prestamo.TotalDeuda = prestamo.Monto + ((prestamo.Monto * prestamo.Interes)/100);
            prestamo.Saldo = prestamo.TotalDeuda;
            prestamo.Estado = "Activo";
            prestamo.UserReg = "Admin";
            _context.Prestamo.Add(prestamo);
            _context.SaveChanges();
            return RedirectToAction("Prestamos");
        }
        public IActionResult EditarPrestamo()
        {
            return View();
        }
        public IActionResult NuevoPago(int IdPrestamo, int IdCliente)
        {
            PrestamoClientes Prestamocliente = new PrestamoClientes();
            Prestamocliente.Prestamos = _context.Prestamo.Where(p => p.IdPrestamo == IdPrestamo).ToList();
            Prestamocliente.Clientes = _context.Clientes.Where(c => c.IdCliente == IdCliente).ToList();
            return View(Prestamocliente);
        }
        public IActionResult Pagos()
        {
            PagosClientes Pagoscliente = new PagosClientes();
            Pagoscliente.Clientes = _context.Clientes.ToList();
            Pagoscliente.Prestamos = _context.Prestamo.ToList();
            Pagoscliente.Pagos = _context.Pagos.ToList();


            return View(Pagoscliente);
        }
        public IActionResult VerPagosPrestamo(int IdCliente, int IdPrestamo)
        {
            PagosClientes Pagoscliente = new PagosClientes();
            Pagoscliente.Clientes = _context.Clientes.Where(c => c.IdCliente == IdCliente).ToList();
            Pagoscliente.Prestamos = _context.Prestamo.Where(pr => pr.IdPrestamo == IdPrestamo).ToList();
            Pagoscliente.Pagos = _context.Pagos.Where(pa => pa.IdPrestamo == IdPrestamo).ToList();


            return View("Pagos", Pagoscliente);
        }
        public IActionResult GuardarPago(Pagos pagos)
        {
            Prestamo prestamo = _context.Prestamo.Where(a => a.IdPrestamo == pagos.IdPrestamo).FirstOrDefault();
            pagos.FechaPago = DateTime.Now;
            pagos.UserReg = "Admin";
            pagos.Saldo = prestamo.Saldo - pagos.MontoPagado;
            _context.Pagos.Add(pagos);

            Prestamo prestamos = _context.Prestamo.Where(a => a.IdPrestamo == pagos.IdPrestamo).FirstOrDefault();
            prestamos.Saldo = pagos.Saldo;

            if (prestamos.Saldo == 0)
                prestamos.Estado = "Pagado";

            _context.SaveChanges();
           
            return RedirectToAction("Pagos");
        }
    }
}
