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

    [RelayCommand]
    public void Save()
    {
        var result = _productService.Update(Product);
        if (result.Success)
        {

            var viewModel = _serviceProvider.GetRequiredService<MainViewWindowModel>();
            viewModel.CurrentViewModel = _serviceProvider.GetRequiredService<OverViewModel>();
        }
    }
    [RelayCommand]
    public void Close()

    {
        var viewModel = _serviceProvider.GetRequiredService<MainViewWindowModel>();
        viewModel.CurrentViewModel = _serviceProvider.GetRequiredService<OverViewModel>();

    }
}
