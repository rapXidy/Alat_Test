using ALATTestAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ALATTestAPI.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {

        }
        public DbSet<State> States { get; set; }
        public DbSet<LGA> lGAs { get; set; }
        public DbSet<Customer> customers { get; set; }
        public DbSet<OTP> oTPs { get; set; }
    }
}
