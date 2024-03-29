
using CommunityToolkit.Mvvm.ComponentModel;
using Punjab_Ornaments.Infrastructure.Database;
using Punjab_Ornaments.Infrastructure.Navigation;

namespace Punjab_Ornaments.Presentation.Viewmodels
{
    public class BaseViewModel : ObservableObject
    {
        protected readonly IDataService _dataService;
        protected readonly INavigationService _navigationService;
        private bool _isBusy;

        public BaseViewModel(IDataService localDataService, INavigationService navigationService)
        {
            _dataService = localDataService;
            _navigationService = navigationService;
        }

        public bool IsBusy
        {
            get => _isBusy;
            set
            {
                _isBusy = value;
                OnPropertyChanged(nameof(IsBusy));
            }
        }

        protected virtual Task InitializeAsync(object obj)
        {
            return Task.CompletedTask;
        }
    }
}
