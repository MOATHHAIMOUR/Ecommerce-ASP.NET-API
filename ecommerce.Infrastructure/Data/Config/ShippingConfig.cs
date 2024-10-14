using Ecommerce.Domain.Entites;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Infrastructure.Data.Config
{
    public class ShippingConfig : IEntityTypeConfiguration<Shipping>
    {
        public void Configure(EntityTypeBuilder<Shipping> builder)
        {
            builder.HasKey(s => s.Id);

            builder.Property(s => s.Carrier)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(s => s.TrackingNumber)
                .HasMaxLength(50);

            builder.Property(s => s.Status)
                .HasMaxLength(50);

        }
    }
}
