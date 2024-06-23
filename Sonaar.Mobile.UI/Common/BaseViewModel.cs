using System;
using Sonaar.Mobile.Services.Navigation;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Sonaar.Mobile.UI.Common
{
	public class BaseViewModel : ObservableObject
    {
        protected readonly INavigationService _navigationService;

        public BaseViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        protected virtual Task InitializeAsync(object obj)
        {
            return Task.CompletedTask;
        }
    }
}

