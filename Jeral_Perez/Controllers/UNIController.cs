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
            //List<Cliente> clientes = _context.Clientes.ToList();
            List<ClientePrestamo> prestamos = new List<ClientePrestamo>();
            string Cadena = "Server=.;Database=Jeral_Perez;Trusted_Connection=True;MultipleActiveResultSets=true";
            SqlConnection conn = new SqlConnection(Cadena);
            conn.Open();
            string consulta = "select * from [Jeral_Perez].[dbo].[VistaClientesPrestamo]";
            SqlCommand cmd = new SqlCommand(consulta, conn);
            SqlDataReader Reader = cmd.ExecuteReader();
            while (Reader.Read())
            {
                ClientePrestamo clientes = new ClientePrestamo();
                clientes.NombreCliente = Convert.ToString(Reader["Cliente"]);
                clientes.Cedula = Convert.ToString(Reader["Cedula"]);
                clientes.Direccion = Convert.ToString(Reader["Direccion"]);
                clientes.TotalDeuda = (decimal)Reader["TotalDeuda"];
                clientes.Saldo = (decimal)Reader["Saldo"];
                prestamos.Add(clientes);
            }
            conn.Close();
            return View(prestamos);
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

        public IActionResult Prestamos()
        {
            //List<Prestamo> prestamos = _context.Prestamo.ToList();
            List<PrestamoClientes> prestamos = new List<PrestamoClientes>();
            string Cadena = "Server=.;Database=Jeral_Perez;Trusted_Connection=True;MultipleActiveResultSets=true";
            SqlConnection conn = new SqlConnection(Cadena);
            conn.Open();
            string consulta = "select * from [Jeral_Perez].[dbo].[VistaPrestamoClientes]";
            SqlCommand cmd = new SqlCommand(consulta, conn);
            SqlDataReader Reader = cmd.ExecuteReader();
            while (Reader.Read())
            {
                PrestamoClientes prestamo = new PrestamoClientes();
                prestamo.Cliente = Convert.ToString(Reader["Cliente"]);
                prestamo.Monto = (decimal)Reader["Monto"];
                prestamo.Interes = (int)Reader["Interes"];
                prestamo.Plazo = (int)Reader["Plazo"];
                prestamo.Saldo = (decimal)Reader["Saldo"];
                prestamos.Add(prestamo);
            }
            conn.Close();

            return View(prestamos);
        }
        public IActionResult NuevoPrestamo()
        {
            List<ClientePrestamo> clientes = new List<ClientePrestamo>();
            string Cadena = "Server=.;Database=Jeral_Perez;Trusted_Connection=True;MultipleActiveResultSets=true";
            SqlConnection conn = new SqlConnection(Cadena);
            conn.Open();
            string consulta = "select IdCliente, Nombres+' '+Apellidos as Cliente from [Jeral_Perez].[dbo].[Clientes]";
            SqlCommand cmd = new SqlCommand(consulta, conn);
            SqlDataReader Reader = cmd.ExecuteReader();
            while (Reader.Read())
            {
                ClientePrestamo cliente = new ClientePrestamo();
                cliente.IdCliente = (int)(Reader["IdCliente"]);
                cliente.NombreCliente = Convert.ToString(Reader["Cliente"]);

                clientes.Add(cliente);
            }
            conn.Close();
            return View(clientes);
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
        public IActionResult NuevoPago()
        {
            List<ClientePrestamo> clientes = new List<ClientePrestamo>();
            string Cadena = "Server=.;Database=Jeral_Perez;Trusted_Connection=True;MultipleActiveResultSets=true";
            SqlConnection conn = new SqlConnection(Cadena);
            conn.Open();
            string consulta = "select p.IdPrestamo, C.Nombres+' '+C.Apellidos as Cliente from [Jeral_Perez].[dbo].[Clientes] C JOIN Prestamo P on c.IdCliente = p.IdCliente";
            SqlCommand cmd = new SqlCommand(consulta, conn);
            SqlDataReader Reader = cmd.ExecuteReader();
            while (Reader.Read())
            {
                ClientePrestamo cliente = new ClientePrestamo();
                cliente.IdCliente = (int)(Reader["IdPrestamo"]);
                cliente.NombreCliente = Convert.ToString(Reader["Cliente"]);
                clientes.Add(cliente);
            }
            conn.Close();
            return View(clientes);
        }
        public IActionResult Pagos()
        {
            List<PagosCliente> Pagos = new List<PagosCliente>();
            string Cadena = "Server=.;Database=Jeral_Perez;Trusted_Connection=True;MultipleActiveResultSets=true";
            SqlConnection conn = new SqlConnection(Cadena);
            conn.Open();
            string consulta = "SELECT C.Nombres+' '+C.Apellidos AS Cliente, p.TotalDeuda, pa.MontoPagado, Convert(varchar,pa.FechaPago, 103) as FechaPago, Pa.Saldo FROM Pagos Pa JOIN Prestamo P ON PA.IdPrestamo = P.IdPrestamo JOIN Clientes C ON P.IdCliente = C.IdCliente";
            SqlCommand cmd = new SqlCommand(consulta, conn);
            SqlDataReader Reader = cmd.ExecuteReader();
            while (Reader.Read())
            {
                PagosCliente Pago = new PagosCliente();
                Pago.Cliente = Reader["Cliente"].ToString();
                Pago.TotalDeuda = (decimal)Reader["TotalDeuda"];
                Pago.MontoPagado = (decimal)Reader["MontoPagado"];
                Pago.FechaPago = Reader["FechaPago"].ToString();
                Pago.Saldo = (decimal)Reader["Saldo"];
                Pagos.Add(Pago);
            }
            conn.Close();
            return View(Pagos);
        }
        public IActionResult GuardarPago(Pagos pagos)
        {
            pagos.FechaPago = DateTime.Now;
            pagos.UserReg = "Admin";
            pagos.Saldo = pagos.Saldo - pagos.MontoPagado;
            _context.Pagos.Add(pagos);
            _context.SaveChanges();
            return RedirectToAction("Pagos");
        }
        public IActionResult Test()
        {
            return View("Postgrado");
        }
    }
}
