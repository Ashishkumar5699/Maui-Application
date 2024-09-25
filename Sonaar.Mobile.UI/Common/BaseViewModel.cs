using Sonaar.Mobile.Services.Navigation;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Sonaar.Mobile.UI.Common
{
	public abstract partial class BaseViewModel(INavigationService navigationService) : ObservableObject
    {
        protected readonly INavigationService _navigationService = navigationService;

        public virtual Task InitializeAsync(object obj = null)
        {
            return Task.CompletedTask;
        }

        [ObservableProperty]
        string title;

        [ObservableProperty]
        bool isBusy;

        [ObservableProperty]
        private double progress;
    }
}

