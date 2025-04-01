using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using DataLayer.Models;
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
                options.UseSqlite("Data Source=TiendaElectronicaSqlite.db;"));

            using (var serviceProvider = services.BuildServiceProvider())
            {
                using (var context = serviceProvider.GetRequiredService<Db_Context>())
                {
                    context.Database.EnsureCreated(); // Crea la BD si no existe
                }
            }

            Application.Run(new Form1()); // Asegurate de que Form1 es tu formulario principal
        }
    }
}