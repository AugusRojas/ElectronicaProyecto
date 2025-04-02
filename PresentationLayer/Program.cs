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
                options.UseSqlite("Data Source=C:\\Users\\Licha\\source\\repos\\LisandroGabrielReinoso\\ElectronicaProyecto\\DataLayer\\TiendaElectronicaSqlite.db"));
            services.AddScoped<Form1>(); // se van a ir inyecctando los formularios para que tengan la configuracion completa de la bd y poder acceder a las tablas y a sus metodos 

            using (var serviceProvider = services.BuildServiceProvider())
            {
                using (var context = serviceProvider.GetRequiredService<Db_Context>())
                {
                    context.Database.EnsureCreated(); // Crea la BD si no existe
                    Application.Run(serviceProvider.GetRequiredService<Form1>());
                }
            }
        }
    }
}