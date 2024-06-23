using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Sonaar.Mobile.Services.AuthService;
using Sonaar.Mobile.Services.Navigation;
using Sonaar.Mobile.UI.Common;

namespace Sonaar.Mobile.UI.Authentication
{
    public partial class AuthPageViewModel : BaseViewModel
    {
        private readonly IAuthService _authService;
        #region Constructor
        public AuthPageViewModel(INavigationService navigationService, IAuthService authService) : base(navigationService)
        {
            _authService = authService;
        }
        #endregion

        #region Commands and Action

        [RelayCommand]
        private async Task LoginAction()
        {
            var isAuthorized = await _authService.LoginUser(UserName, Password);

            if (isAuthorized.Data != null && isAuthorized.Data.IsUserloggedin)
            {
                Application.Current.MainPage = new AppShell();
            }
        }
        #endregion

        #region Bindbale Property

        [ObservableProperty]
        public string userName = "string";

        [ObservableProperty]
        public string password = "string";

        #endregion

    }
}

