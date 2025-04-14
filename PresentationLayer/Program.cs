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
            QuestPDF.Settings.License = QuestPDF.Infrastructure.LicenseType.Community;


            // Configuración de la base de datos
            var services = new ServiceCollection();
            var documentosPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "TiendaElectronicaSqlite.db");
            services.AddDbContext<Db_Context>(options =>
                options.UseSqlite($"Data Source={dbPath};"));

            //Repositorios
            services.AddScoped<IProduct, ProductRepository>();
            services.AddScoped<ICategory, CategoryRepository>();
            services.AddScoped<IPaymentMethods, PaymentMethodRepository>();
            services.AddScoped<ISale, SaleRepository>();
            services.AddScoped<IProductsXSales, ProductsXSalesRepository>();
            services.AddScoped<ProductsXSales>();

            //Servicios de validacion
            services.AddScoped<IValidator<Category>, CategoryRepositoryValidation>();  // Registra el validador de Category
            services.AddScoped<IValidator<List<Category>>, CategoriesRepositoryValidation>();
            services.AddScoped<IValidator<Product>, ProductRepositoryValidation>();  // Registra el validador de Product
            //services.AddScoped<IValidator<Sale>, SaleRepositoryValidation> ();  // Registra el validador de Sale
            services.AddScoped<IValidator<PaymentMethod>, PaymentMethodRepositoryValidation>();
            services.AddScoped<IValidator<Product>, SaleRepositoryValidation>();

            //Servicios
            services.AddScoped<CategoryService>();
            services.AddScoped<ProductService>();
            services.AddScoped<PaymentMethodService>();
            services.AddScoped<SaleService>();
            services.AddScoped<ProductsXSalesService>();

            //Formularios
            services.AddScoped<ProductWindows>();
            services.AddScoped<Sales>();
            services.AddScoped<CashClosing>();

            var serviceProvider = services.BuildServiceProvider();

            //Asegurar que la BD está creada
            var context = serviceProvider.GetRequiredService<Db_Context>();
            if (!context.Database.CanConnect())
            {
                MessageBox.Show("No se pudo conectar a la base de datos.");
            }


            // Lanzar la aplicación
            Application.Run(serviceProvider.GetRequiredService<Sales>());
        }
    }
}
