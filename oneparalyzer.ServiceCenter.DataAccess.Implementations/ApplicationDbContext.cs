using Microsoft.EntityFrameworkCore;
using oneparalyzer.ServiceCenter.DataAccess.Implementations.EntityTypeConfigurations;
using oneparalyzer.ServiceCenter.DataAccess.Interfaces;
using oneparalyzer.ServiceCenter.Domain.Entities;


namespace oneparalyzer.ServiceCenter.DataAccess.Implementations
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Spare> Spares { get; set; }
        public DbSet<SpareOrder> SparesOrders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ClientConfiguration());
            modelBuilder.ApplyConfiguration(new OrderConfiguration());
            modelBuilder.ApplyConfiguration(new ServiceConfiguration());
            modelBuilder.ApplyConfiguration(new SpareConfiguration());
            modelBuilder.ApplyConfiguration(new SpareOrderConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
