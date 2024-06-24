
using CommunityToolkit.Mvvm.ComponentModel;
using Sonaar.Infrastructure.Database;
using Sonaar.Infrastructure.Navigation;

namespace Sonaar.Presentation.Viewmodels
{
    public class BaseViewModel : ObservableObject
    {
        protected readonly IDataService _dataService;
        protected readonly INavigationService _navigationService;
        public BaseViewModel(IDataService localDataService, INavigationService navigationService)
        {
            _dataService = localDataService;
            _navigationService = navigationService;
        }

        protected virtual Task InitializeAsync(object obj)
        {
            return Task.CompletedTask;
        }
    }
}
