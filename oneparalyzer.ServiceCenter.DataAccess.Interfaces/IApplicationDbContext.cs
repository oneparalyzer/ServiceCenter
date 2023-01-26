using Microsoft.EntityFrameworkCore;
using oneparalyzer.ServiceCenter.Domain.Entities;

namespace oneparalyzer.ServiceCenter.DataAccess.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Client> Clients { get; set; }
        DbSet<Order> Orders { get; set; }
        DbSet<Service> Services { get; set; }
        DbSet<Spare> Spares { get; set; }
        DbSet<SpareOrder> SparesOrders { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
