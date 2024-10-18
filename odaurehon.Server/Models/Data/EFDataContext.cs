using Microsoft.EntityFrameworkCore;

namespace Server.Models.Data
{
    public class EFDataContext : DbContext
    {
        public EFDataContext(DbContextOptions<EFDataContext> options) : base(options)
        {

        }

        public DbSet<Customer> Users { get; set; }
        public DbSet<Bus> Buses { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<BusRoute> BusRoutes { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Ticket> Ticket { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
