using Labb1.Models;
using Microsoft.EntityFrameworkCore;

namespace Labb1.Data
{
    public class Labb1DbContext : DbContext
    {
        public Labb1DbContext(DbContextOptions<Labb1DbContext> options) : base(options)
        {

        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Vacation> Vacations { get; set; }
    }
}
