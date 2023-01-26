using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using oneparalyzer.ServiceCenter.Domain.Entities;


namespace oneparalyzer.ServiceCenter.DataAccess.Implementations.EntityTypeConfigurations
{
    public class SpareOrderConfiguration : IEntityTypeConfiguration<SpareOrder>
    {
        public void Configure(EntityTypeBuilder<SpareOrder> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Quantity).IsRequired();
        }
    }
}
