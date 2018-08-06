using Microsoft.EntityFrameworkCore;

namespace CrossSolar.Domain
{
    public class CrossSolarDbContext : DbContext
    {
        public static DbContextOptions<CrossSolarDbContext> optionsInternal;

        public CrossSolarDbContext()
        {
        }

        public CrossSolarDbContext(DbContextOptions<CrossSolarDbContext> options) : base(options)
        {
            optionsInternal = options;
        }

        public DbSet<Panel> Panels { get; set; }

        public DbSet<OneHourElectricity> OneHourElectricitys { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}