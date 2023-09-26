using Microsoft.EntityFrameworkCore;
using TestHelmi.Models;

namespace TestHelmi.Data
{
    public class MySqlContext : DbContext
    {
        public MySqlContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Penjualan> market { get; set; }
    }
}
