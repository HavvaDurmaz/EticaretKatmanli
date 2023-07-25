using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.DataMapping
{
    public class OrderAddressMap : IEntityTypeConfiguration<OrderAddress>
    {
        public void Configure(EntityTypeBuilder<OrderAddress> builder)
        {

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.District).HasMaxLength(50).IsRequired();
            builder.Property(x => x.City).HasMaxLength(50).IsRequired();
            builder.Property(x => x.FullAddress).HasMaxLength(350).IsRequired();
            builder.Property(x => x.AddressName).HasMaxLength(30).IsRequired();
            builder.Property(x => x.AddressType).IsRequired();
            builder.Property(x => x.CustomersId).IsRequired();
            builder.Property(x => x.CookieID).IsRequired();

            builder.HasOne(x => x.Customers).WithMany(x => x.OrderAdress).HasForeignKey(x => x.CustomersId);
            builder.HasOne(x => x.Orders).WithMany(x => x.OrderAddress).HasForeignKey(x => x.CookieID);

            builder.ToTable("OrderAddress");

        }
    }
}