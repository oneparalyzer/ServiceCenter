using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using oneparalyzer.ServiceCenter.Domain.Entities;


namespace oneparalyzer.ServiceCenter.DataAccess.Implementations.EntityTypeConfigurations
{
    public class SpareConfiguration : IEntityTypeConfiguration<Spare>
    {
        public void Configure(EntityTypeBuilder<Spare> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Title).IsRequired();
            builder.Property(x => x.Device).IsRequired();
            builder.Property(x => x.Details).IsRequired();
            builder.Property(x => x.Price).IsRequired();
            builder.Property(x => x.Quantity).IsRequired();

            builder.HasIndex(x => x.Title).IsUnique();

        }
    }
}
