using Jeral_Perez.Models;
using Microsoft.EntityFrameworkCore;

namespace Jeral_Perez.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {

        }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Prestamo> Prestamo { get; set; }
        public DbSet<Pagos> Pagos { get; set; }
    }
}
