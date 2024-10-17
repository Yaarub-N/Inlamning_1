
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using Resources.Interface;
using Resources.Models;
using System.Collections.ObjectModel;

namespace GUI.ViewModels;

public partial class OverViewModel : ObservableObject
{
    private readonly IServiceProvider _serviceProvider;
    private readonly IProductService _productService;


    public OverViewModel(IServiceProvider serviceProvider, IProductService productService)
    {
        _serviceProvider = serviceProvider;
        _productService = productService;
        UpdateProductList();
    }

    [ObservableProperty]
    private ObservableCollection<Product> _productList = [];

    [RelayCommand]

    public void Add()
    {
        var viewModel = _serviceProvider.GetRequiredService<MainViewWindowModel>();
        viewModel.CurrentViewModel = _serviceProvider.GetRequiredService<CreateViewModel>();
    }


    //testa tabort parameterena

    [RelayCommand]
    public void Edit(Product product)
    {
        var editViewModel= _serviceProvider.GetRequiredService<EditViewModel>();
        editViewModel.Product = product;

        var viewModel = _serviceProvider.GetRequiredService<MainViewWindowModel>();
        viewModel.CurrentViewModel= editViewModel;
    
        UpdateProductList();
    }

    [RelayCommand]

    public void Delete(string id)
    {
        _productService.DeleteProduct(id);
        UpdateProductList();
    }

    public void UpdateProductList()
    {
        ProductList.Clear();
        foreach (var product in _productService.GetAllProductService())
        {
            ProductList.Add(product);
        }
    }
}



