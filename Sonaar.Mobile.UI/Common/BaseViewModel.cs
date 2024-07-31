using Sonaar.Mobile.Services.Navigation;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Sonaar.Mobile.UI.Common
{
	public abstract class BaseViewModel : ObservableObject
    {
        protected readonly INavigationService _navigationService;

        public BaseViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public virtual Task InitializeAsync(object obj = null)
        {
            return Task.CompletedTask;
        }
    }
}

