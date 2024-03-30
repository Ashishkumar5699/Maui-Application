
using CommunityToolkit.Mvvm.ComponentModel;
using Punjab_Ornaments.Infrastructure.Database;
using Punjab_Ornaments.Infrastructure.Navigation;

namespace Punjab_Ornaments.Presentation.Viewmodels
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
