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
            _context.Clientes.Add(cliente);
            _context.SaveChanges();
            return RedirectToAction("Clientes");
        }

        public IActionResult Prestamos()
        {
            List<Prestamo> prestamos = _context.Prestamo.ToList();
            return View(prestamos);
        }
        public IActionResult NuevoPrestamo()
        {
            return View();
        }
        public IActionResult GuardarPrestamo(Prestamo prestamo)
        {
            prestamo.FechaReg = DateTime.Now;
            prestamo.TotalDeuda = prestamo.Monto+ ((prestamo.Monto * prestamo.Interes)/100);
            prestamo.Saldo = prestamo.TotalDeuda;
            prestamo.Estado = "Activo";
            _context.Prestamo.Add(prestamo);
            _context.SaveChanges();
            return RedirectToAction("Prestamos");
        }
        public IActionResult NuevoPago()
        {
            return View();
        }
        public IActionResult Pagos()
        {
            return View();
        }
        public IActionResult Test()
        {
            return View("Postgrado");
        }
    }
}
