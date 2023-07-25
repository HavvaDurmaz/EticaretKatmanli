using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DataMapping
{
    public class TemporaryBasketMap : IEntityTypeConfiguration<TemporaryBasket>
    {
        public void Configure(EntityTypeBuilder<TemporaryBasket> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.ImagesHome).HasMaxLength(50);
            builder.Property(x => x.Price).HasColumnType("money");
            builder.Property(x => x.ProductName).HasMaxLength(50).IsRequired();
            builder.Property(x => x.Piece).IsRequired();
            builder.Property(x => x.CookieID).IsRequired();

            builder.ToTable("TemporaryBasket");
        }
    }
}
