using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using DataLayer.Models;
using DataLayer.Interfaces;
using DataLayer.Repositories;
using LogicLayer.ValidationRepositories;
using LogicLayer.ValidatorService;
using FluentValidation;

namespace PresentationLayer
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Configuración de la base de datos
            var services = new ServiceCollection();
            services.AddDbContext<Db_Context>(options =>
                options.UseSqlite(@"Data Source=C:\\Users\\Licha\\source\\repos\\AugusRojas\\ElectronicaProyecto\\DataLayer\\TiendaElectronicaSqlite.db"));

            //Repositorios
            services.AddScoped<IProduct, ProductRepository>();
            services.AddScoped<ICategory, CategoryRepository>();
            services.AddScoped<IPaymentMethods, PaymentMethodRepository>();
            services.AddScoped<ISale, SaleRepository>();

            //Servicios de validacion
            services.AddScoped<IValidator<Category>, CategoryRepositoryValidation>();  // Registra el validador de Category
            services.AddScoped<IValidator<List<Category>>, CategoriesRepositoryValidation>();
            services.AddScoped<IValidator<Product>, ProductRepositoryValidation>();  // Registra el validador de Product
            //services.AddScoped<IValidator<Sale>, SaleRepositoryValidation> ();  // Registra el validador de Sale

            //Servicios
            services.AddScoped<CategoryService>();
            services.AddScoped<ProductService>();
            services.AddScoped<PaymentMethodService>();
            services.AddScoped<SaleService>();

            //Formularios
            services.AddScoped<Form1>();
            services.AddScoped<ProductWindows>();
            services.AddScoped<Sales>();

            var serviceProvider = services.BuildServiceProvider();

            // Asegurar que la BD está creada
            var context = serviceProvider.GetRequiredService<Db_Context>();
            context.Database.EnsureCreated();
            

            // Lanzar la aplicación
            Application.Run(serviceProvider.GetRequiredService<Sales>());
        }
    }
}
