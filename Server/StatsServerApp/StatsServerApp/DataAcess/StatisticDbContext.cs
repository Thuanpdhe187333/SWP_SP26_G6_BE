using Microsoft.EntityFrameworkCore;

namespace StatsDataServer.DataAccess
{
    public class StatisticDbContext : DbContext
    {
        public DbSet<StatisticType> StatisticTypes { get; set; }
        public DbSet<StatisticRecord> StatisticRecords { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(
                "Server=DUCTHUAN\\SQLEXPRESS;Database=Northwind;Trusted_Connection=True;TrustServerCertificate=True"
            );
        }
    }
}
