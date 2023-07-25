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
    public class CustomersMap : IEntityTypeConfiguration<Customers>
    {
        public void Configure(EntityTypeBuilder<Customers> builder)
        {
            builder.HasKey(x=> x.Id);
            builder.Property(x=> x.Id).ValueGeneratedOnAdd();
            builder.Property(x=> x.NameSurName).HasMaxLength(50).IsRequired();
            builder.Property(x => x.Email).HasMaxLength(50).IsRequired();
            builder.Property(x => x.Phone).HasMaxLength(15).IsRequired();
            builder.Property(x => x.Passwords).HasMaxLength(15).IsRequired();
            builder.Property(x => x.RegisterDate).HasColumnType("Date").HasDefaultValue(DateTime.Now);

            builder.HasMany(x => x.OrderAdress).WithOne(x => x.Customers).HasForeignKey(x => x.CustomersId);

            builder.ToTable("Customers");
        }
    }
}
