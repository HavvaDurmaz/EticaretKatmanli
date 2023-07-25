using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.DataMapping
{
    public class OrderDetailsMap : IEntityTypeConfiguration<OrderDetails>
    {
        public void Configure(EntityTypeBuilder<OrderDetails> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.ImagesHome).HasMaxLength(50);
            builder.Property(x => x.Price).HasColumnType("money");
            builder.Property(x => x.ProductName).HasMaxLength(50).IsRequired();
            builder.Property(x => x.Piece).IsRequired();
            builder.Property(x => x.CookieId).IsRequired();

            builder.HasOne(x=>x.Orders).WithMany(x=>x.OrderDetails).HasForeignKey(x=>x.CookieId);

            builder.ToTable("OrderDetails");
        }
    }
}
