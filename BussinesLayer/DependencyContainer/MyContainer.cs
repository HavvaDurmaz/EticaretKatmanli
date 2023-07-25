using BussinesLayer.Abstract;
using BussinesLayer.Concrete;
using BussinesLayer.FluentValidations;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities.Concrete;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer.DependencyContainer
{
    public static class MyContainer
    {
        public static IServiceCollection Instance(this IServiceCollection services)
        {
            services.AddScoped<IProductsRepo, ProductsRepo>();
            services.AddScoped<ICustomersRepo, CustomersRepo>();
            services.AddScoped<IOrderAddressRepo, OrderAddressRepo>();
            services.AddScoped<IOrderDetailsRepo, OrderDetailsRepo>();
            services.AddScoped<IOrdersRepo, OrdersRepo>();
            services.AddScoped<ITemporaryBasketRepo, TemporaryBasketRepo>();
            services.AddScoped<ICategoriesRepo, CategoriesRepo>();


            // Tanımladığımız Validasyonları Türetme Aşamaları 
            // Her Client ayrı nesne üretmek yerne Proje yaşam süresi boyunca 1 Nesne türetilip bütün Client'lara aynı nesnein verilmesini sağlayan  Türetme mantığına Singleton(Tek Nesne) denir.

            services.AddSingleton<IValidator<Customers>, CustomerValidation>();
            services.AddSingleton<IValidator<Categories>, CategoriesValidation>();
            services.AddSingleton<IValidator<OrderAddress>, OrderAddressValidation>();
            services.AddSingleton<IValidator<Products>, ProductsValidation>();

            // Manager Sınıflarının Türetilmesi
            services.AddScoped<IProductsManager, ProductsManager>();
            services.AddScoped<ICustomersManager,CustomerManager>();
            services.AddScoped<IOrdersManager, OrdersManager>();
            services.AddScoped<ITemporaryManager, TemporaryManager>();
            services.AddScoped<ICategoriesManager, CategoriesManager>();

            return services;
        }
    }
}
