using System;
using Jeral_Perez.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;

namespace Jeral_Perez.Controllers
{
    public class UNIController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Clientes()
        {
            //SqlConnection Conexion = new SqlConnection("server = DESKTOP-LN2IU17; database = Jeral_Perez; integrated security = true");
            //Conexion.Open();
            //string cadena = "select C.Nombres+' '+C.Apellidos as NombreCompleto, C.Cedula, C.Direccion, convert(int,P.Monto) as Monto, convert(int,P.Saldo) as Saldo from TblClientes C left join TblPrestamos P on C.IdCliente = P.IdCliente";
            //SqlCommand comando = new SqlCommand(cadena, Conexion);
            //SqlDataReader Registros = comando.ExecuteReader();
            //List<ClientePrestamo> cliente = new List<ClientePrestamo>();
            //while (Registros.Read())
            //{
            //    cliente.Add(new ClientePrestamo
            //    {
            //        Nombre = Registros["NombreCompleto"].ToString(),
            //        Cedula = Registros["Cedula"].ToString(),
            //        Direccion = Registros["Direccion"].ToString(),
            //        Monto = Registros["Monto"].ToString(),
            //        Saldo = Registros["Saldo"].ToString()
            //    });
            //}
            //Conexion.Close();
            //return View(cliente);
            return View();
        }

        public IActionResult Pagos()
        {
            //SqlConnection Conexion = new SqlConnection("server = DESKTOP-LN2IU17; database = Jeral_Perez; integrated security = true");
            //Conexion.Open();
            //string cadena = "select C.Nombres+' '+C.Apellidos as NombreCompleto, convert(int,P.Monto) as Prestamo, convert(int,PA.MontoPagado) as MontoPagado, PA.FechaPago, convert(int,PA.SaldoPago) as Saldo from TblClientes C join TblPrestamos P on C.IdCliente = P.IdCliente join TblPagos PA on P.IdPrestamo = PA.IdPrestamo order by NombreCompleto, FechaPago";
            //SqlCommand comando = new SqlCommand(cadena, Conexion);
            //SqlDataReader Registros = comando.ExecuteReader();
            //List<Pagos> Pagos = new List<Pagos>();
            //while (Registros.Read())
            //{
            //    Pagos.Add(new Pagos
            //    {
            //        NombreCompleto = Registros["NombreCompleto"].ToString(),
            //        Prestamo = Registros["Prestamo"].ToString(),
            //        MontoPagado = (int)Registros["MontoPagado"],
            //        FechaPago = Registros["FechaPago"].ToString(),
            //        Saldo = (int)Registros["Saldo"]
            //    });
            //}
            //Conexion.Close();
            //return View(Pagos);
            return View();
        }
        public IActionResult Test()
        {
            return View("Postgrado");
        }
        public IActionResult AgregarClientes()
        {
            return View();
        }
        public IActionResult NuevoPago()
        {
            return View();
        }
    }
}
