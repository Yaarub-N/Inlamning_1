
using GUI.ViewModels;
using GUI.Views;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Resources.Interface;
using Resources.Services;
using System.IO;
using System.Windows;

namespace GUI;


public partial class App : Application
{

    private readonly IHost _host;

    public App()
    {
        var baseDiroctory = AppDomain.CurrentDomain.BaseDirectory;
        string filePath = Path.Combine(baseDiroctory, "producr.json");

        _host = Host.CreateDefaultBuilder()
            .ConfigureServices((context, services) =>
            {
                services.AddSingleton<IProductService ,ProductService>();
                services.AddSingleton<IFileService>(new FileService(filePath));

                services.AddSingleton<MainWindow>();
                services.AddSingleton<MainViewWindowModel>();

                services.AddTransient<OverView>();
                services.AddTransient<OverViewModel>();

                services.AddTransient<CreateViewModel>();
                services.AddTransient<CreateView>();

                services.AddTransient<EditViewModel>();
                services.AddTransient<EditView>();

            }).Build();
    }

    protected override async void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);
        await _host.StartAsync();
        var mainWindow = _host.Services.GetRequiredService<MainWindow>();
        mainWindow.DataContext = _host.Services.GetRequiredService<MainViewWindowModel>();
        mainWindow.Show();
    }

}

