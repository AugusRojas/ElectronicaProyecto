using DataLayer.Models;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows.Forms;


static class Program
{
    [STAThread]
    static void Main()
    {
        var services = new ServiceCollection();

        // Asegúrate de que la referencia está bien agregada aquí
        services.AddScoped<IProduct, ProductRepository>();

        services.AddDbContext<TiendaDbContext>(options =>
            options.UseSqlite("Data Source=Tienda.db"));

        services.AddTransient<Form1>();

        using (var serviceProvider = services.BuildServiceProvider())
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var formPrincipal = serviceProvider.GetRequiredService<Form1>();
            Application.Run(formPrincipal);
        }
    }
}
