﻿using System;
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
            prestamo.TotalDeuda = prestamo.Monto+ ((prestamo.Monto * prestamo.Interes)/100);
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
        public IActionResult NuevoPago(int IdPrestamo)
        {
            PrestamoClientes Prestamocliente = new PrestamoClientes();
            Prestamocliente.Clientes = _context.Clientes.ToList();
            Prestamocliente.Prestamos = _context.Prestamo.ToList();
            return View(Prestamocliente);

            //List<ClientePrestamo> clientes = new List<ClientePrestamo>();
            //string Cadena = "Server=.;Database=Jeral_Perez;Trusted_Connection=True;MultipleActiveResultSets=true";
            //SqlConnection conn = new SqlConnection(Cadena);
            //conn.Open();
            //string consulta = "select p.IdPrestamo, C.Nombres+' '+C.Apellidos as Cliente from [Jeral_Perez].[dbo].[Clientes] C JOIN Prestamo P on c.IdCliente = p.IdCliente";
            //SqlCommand cmd = new SqlCommand(consulta, conn);
            //SqlDataReader Reader = cmd.ExecuteReader();
            //while (Reader.Read())
            //{
            //    ClientePrestamo cliente = new ClientePrestamo();
            //    cliente.IdCliente = (int)(Reader["IdPrestamo"]);
            //    cliente.NombreCliente = Convert.ToString(Reader["Cliente"]);
            //    clientes.Add(cliente);
            //}
            //conn.Close();
            //return View(clientes);
        }
        public IActionResult Pagos()
        {
            PagosClientes Prestamocliente = new PagosClientes();
            Prestamocliente.Clientes = _context.Clientes.ToList();
            Prestamocliente.Prestamos = _context.Prestamo.ToList();
            Prestamocliente.Pagos = _context.Pagos.ToList();
            return View(Prestamocliente);
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
        public IActionResult Test()
        {
            return View("Postgrado");
        }
    }
}
