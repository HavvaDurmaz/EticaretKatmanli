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
    public class CategoriesMap : IEntityTypeConfiguration<Categories>
    {
        public void Configure(EntityTypeBuilder<Categories> builder)
        {
            builder.HasKey(x => x.id);
            builder.Property(x=> x.id).ValueGeneratedOnAdd();
            builder.Property(x => x.SubCategory).HasDefaultValue(0); // Boş Bırakılırsa Varsayılan olarak 0 Eklensin 
            builder.Property(x=> x.CategoryName).HasMaxLength(50).IsRequired();

            // Many To One => Çok'a Tek İlişki.
            builder.HasMany(x => x.Products).WithOne(x => x.Categories).HasForeignKey(x => x.CategoriesId);
            //public List<Products> Products { get; set; }

            builder.ToTable("Categories");
        }
    }
}
