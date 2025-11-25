using Microsoft.EntityFrameworkCore;

namespace BitcoinAPI.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<BtcRateData> BtcRateData => Set<BtcRateData>();
    }
}
