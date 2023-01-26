using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using oneparalyzer.ServiceCenter.Domain.Entities;


namespace oneparalyzer.ServiceCenter.DataAccess.Implementations.EntityTypeConfigurations
{
    public class ServiceConfiguration : IEntityTypeConfiguration<Service>
    {
        public void Configure(EntityTypeBuilder<Service> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Title).IsRequired();
            builder.Property(x => x.Price).IsRequired();

            builder.HasIndex(x => x.Title).IsUnique();
        }
    }
}
