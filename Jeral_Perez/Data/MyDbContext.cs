using Jeral_Perez.Models;
using Microsoft.EntityFrameworkCore;

namespace Jeral_Perez.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {

        }
        public DbSet<Usuarios> Usuarios { get; set; }
    }
}
