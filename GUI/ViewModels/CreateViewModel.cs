

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
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


    [RelayCommand]
    public void save()
    {
        var result = _productService.AddToList(Product);
        if (result.Success)
        {

            var viewModel = _serviceProvider.GetRequiredService<MainViewWindowModel>();
            viewModel.CurrentViewModel = _serviceProvider.GetRequiredService<OverViewModel>();
        }
    }

    [RelayCommand]
    public void Cancel()
    {
        var viewModel = _serviceProvider.GetRequiredService<MainViewWindowModel>();
        viewModel.CurrentViewModel = _serviceProvider.GetRequiredService<OverViewModel>();
    }
}
