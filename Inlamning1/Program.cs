
using Inlamning1.Menus;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Resources.Interface;
using Resources.Services;
using System;
using System.IO;

namespace Inlamning1;

class Program
{
    private readonly IHost _host;

    public Program(IHost host)
    {
        _host = host;
    }

    static void Main(string[] args)
    {
        var program = new Program(CreateHostBuilder(args).Build());
        program.Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureServices((context, services) =>
            {
                // Konfigurera beroenden
                var baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
                string filePath = Path.Combine(baseDirectory, "product.json");

                services.AddSingleton<IProductService, ProductService>();
                services.AddSingleton<IFileService>(new FileService(filePath));

                services.AddSingleton<Menu>();
                services.AddSingleton<ProductMenu>();
                services.AddSingleton<ProductUnitMenu>();
            });

    public void Run()
    {
        // Starta host
        _host.StartAsync().Wait();

        // Hämta Menu-tjänsten från DI-container och kör applikationen
        var menu = _host.Services.GetRequiredService<Menu>();

        while (true)
        {
            menu.MainMenu();  // Starta huvudmenyn
        }
    }
}
