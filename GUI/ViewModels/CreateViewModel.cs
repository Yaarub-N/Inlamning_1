

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Linq;
using Resources.Interface;
using Resources.Models;

namespace GUI.ViewModels;

public partial class CreateViewModel : ObservableObject
{

    private readonly IServiceProvider _serviceProvider;
    private readonly IProductService _productService;

    public CreateViewModel(IServiceProvider serviceProvider, IProductService productService)
    {
        _serviceProvider = serviceProvider;
        _productService = productService;

    }
    [ObservableProperty]
    private Product _product = new()
    {
        Category = new Category()
    };

    [ObservableProperty]
    private bool invalidNamn;


    [ObservableProperty]
    private bool invalidPrice;

    [RelayCommand]
    public void SaveProduct()
    {
         try
            {
            InvalidNamn = string.IsNullOrWhiteSpace(Product.ProductName);
            InvalidPrice = Product.price <= 0;
            if (!InvalidNamn && !InvalidPrice) 
    {
        var result = _productService.AddToList(Product);
        if (result.Success)
        {

            var viewModel = _serviceProvider.GetRequiredService<MainViewWindowModel>();
            viewModel.CurrentViewModel = _serviceProvider.GetRequiredService<OverViewModel>();

                }
            }
        }
        catch { }   
    }

    [RelayCommand]
    public void Cancel()
    {
        var viewModel = _serviceProvider.GetRequiredService<MainViewWindowModel>();
        viewModel.CurrentViewModel = _serviceProvider.GetRequiredService<OverViewModel>();
    }
}
