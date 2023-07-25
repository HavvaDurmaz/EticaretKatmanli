using DataAccess.DataMapping;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class DatabaseContext:DbContext
    {
        public DbSet<Categories> Categories { get; set; }

        public DbSet<Customers> Customers { get; set; }

        public DbSet<OrderAddress> OrderAddress { get; set; }

        public DbSet<OrderDetails> OrderDetails { get; set; }

        public DbSet<Orders> Orders { get; set;}

        public DbSet<Products> Products { get; set; }            

        public DbSet<TemporaryBasket> TemporaryBasket { get; set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=NIRVANA\SQLEXPRESS;Database=EticaretKatmanli;Trusted_Connection=true;encrypt=false");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoriesMap());
            modelBuilder.ApplyConfiguration(new CustomersMap());
            modelBuilder.ApplyConfiguration(new OrderAddressMap());
            modelBuilder.ApplyConfiguration(new OrderDetailsMap());
            modelBuilder.ApplyConfiguration(new OrdersMap());
            modelBuilder.ApplyConfiguration(new ProductsMap());
            modelBuilder.ApplyConfiguration(new TemporaryBasketMap());
        }
    }
}
