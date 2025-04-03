using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using DataLayer.Models;
using DataLayer.Interfaces;
using DataLayer.Repositories;
using LogicLayer.ValidationRepositories;
using LogicLayer.ValidatorService;

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
                options.UseSqlite("Data Source=\"C:\\Users\\augus\\OneDrive\\Escritorio\\TecnicoOrganizado\\ElectronicaProyecto\\DataLayer\\TiendaElectronicaSqlite.db\""));

            //Repositorios
            services.AddScoped<IProduct, ProductRepository>();
            services.AddScoped<ICategory, CategoryRepository>();

            //Servicios de validacion
            services.AddScoped<ProductRepositoryValidation>();
            services.AddScoped<CategoryRepositoryValidation>();
            services.AddScoped<CategoriesRepositoryValidation>();
            services.AddScoped<CategoryService>();
            services.AddScoped<ProductService>();

            //Formularios
            services.AddScoped<Form1>();

            var serviceProvider = services.BuildServiceProvider();

            // Asegurar que la BD está creada
            var context = serviceProvider.GetRequiredService<Db_Context>();
            context.Database.EnsureCreated();
            

            // Lanzar la aplicación
            Application.Run(serviceProvider.GetRequiredService<Form1>());
        }
    }
}
