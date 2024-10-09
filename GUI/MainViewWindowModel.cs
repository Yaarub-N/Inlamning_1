

using CommunityToolkit.Mvvm.ComponentModel;
using GUI.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace GUI
{
    public partial class MainViewWindowModel:ObservableObject
    {
        private readonly IServiceProvider _serviceProvider;
       

        public  MainViewWindowModel(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            CurrentViewModel = _serviceProvider.GetRequiredService<OverViewModel>();
            
           
        }
        [ObservableProperty]
        private ObservableObject currentViewModel;
    }
}
