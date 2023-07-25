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
    internal class OrdersMap : IEntityTypeConfiguration<Orders>
    {
        public void Configure(EntityTypeBuilder<Orders> builder)
        {
           
            builder.Property(x => x.OrderStatus).HasMaxLength(50).HasDefaultValue("Hazrılanıyor");
            builder.Property(x => x.PaymentDate).HasDefaultValue(DateTime.Now);
            builder.Property(x => x.TotalPrice).HasColumnType("money").IsRequired();
            builder.HasKey(x => x.CookieId);
            builder.Property(x => x.PaymentType).IsRequired().HasMaxLength(35).HasDefaultValue("0");
            builder.Property(x => x.CustomersId).IsRequired();

            builder.HasMany(x => x.OrderAddress).WithOne(x => x.Orders).HasForeignKey(x => x.CookieID);
            builder.HasMany(x => x.OrderDetails).WithOne(x => x.Orders).HasForeignKey(x => x.CookieId);

            builder.ToTable("Orders");

        }
    }
}
