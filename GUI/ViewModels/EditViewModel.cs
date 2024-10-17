using Resources.Models;

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Resources.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace GUI.ViewModels;

public partial class EditViewModel:ObservableObject
{
    private readonly IServiceProvider _serviceProvider;
    private readonly IProductService _productService;

    public EditViewModel(IServiceProvider serviceProvider, IProductService productService)
    {
        _serviceProvider = serviceProvider;
        _productService = productService;
    }
    [ObservableProperty]
    private Product _product = new();


    [ObservableProperty]
    private bool invalidNamn;



    [ObservableProperty]
    private bool invalidPrice;

    [RelayCommand]
    public void Save()
    {

        try
        {

            InvalidNamn = string.IsNullOrWhiteSpace(Product.ProductName);
            InvalidPrice = Product.price <= 0;


            if (!InvalidNamn && !InvalidPrice)
            {
        var result = _productService.Update(Product);
        if (result.Success)
        {

            var viewModel = _serviceProvider.GetRequiredService<MainViewWindowModel>();
            viewModel.CurrentViewModel = _serviceProvider.GetRequiredService<OverViewModel>();
        }
            }
        }
        catch
        {
           
        }
    }
    [RelayCommand]
    public void Close()

    {
        var viewModel = _serviceProvider.GetRequiredService<MainViewWindowModel>();
        viewModel.CurrentViewModel = _serviceProvider.GetRequiredService<OverViewModel>();

    }
}
