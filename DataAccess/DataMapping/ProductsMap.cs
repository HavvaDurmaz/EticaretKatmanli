using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.DataMapping
{
    public class ProductsMap: IEntityTypeConfiguration<Products>
    {
        public void Configure(EntityTypeBuilder<Products>builder) 
        { 
            builder.HasKey(x=> x.Id); // Primary Key
            builder.Property(x=> x.Id).ValueGeneratedOnAdd(); // Otomatik Artan Identity
            builder.Property(x=> x.ImagesDetail).HasMaxLength(50).IsRequired(true); // Boş Geçilemez
            builder.Property(x => x.ImagesDetail2).HasMaxLength(50).IsRequired(true); // Boş Geçilemez
            builder.Property(x => x.ImagesDetail3).HasMaxLength(50).IsRequired(true); // Boş Geçilemez
            builder.Property(x => x.ImagesHome).HasMaxLength(50).IsRequired(); // Boş Geçilemez
            builder.Property(x => x.Price).HasColumnType("money"); // Veritabanında PRİCE veritipi olarak oluşacaktır.
            builder.Property(x => x.ProductsName).HasMaxLength(50).IsRequired();
            builder.Property(x => x.Stock).IsRequired(true); 

            // Her Bir=> Many
            // 1 Adet => One 
            // Her Bir Ürünün 1 Adet Kategorisi Olacaktır. ( One to Many İlişkilendirmesi. ) 

            // 1 Kategorinin 2'den fazla ürünü oluyorsa. Ürünler sınıfında ilişkilendirme yapılacak ise aşağıdaki gibi
            // Ürünler Sınıfında HASONE diye başlanır MANY olarak bitirilir. Tek'e Çok İlişki
            builder.HasOne(x=> x.Categories).WithMany(x => x.Products).HasForeignKey(x=>x.CategoriesId);

            builder.ToTable("Products"); // Products isminde Tablo olarak oluşacaktır. 
        }
    } 
}
