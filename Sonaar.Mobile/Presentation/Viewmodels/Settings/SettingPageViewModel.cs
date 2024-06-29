using Sonaar.Infrastructure.Database;
using Sonaar.Infrastructure.Navigation;
using Sonaar.Resources.Constant;
using Sonaar.Mobile.UI.Authentication;
using System.Windows.Input;

namespace Sonaar.Presentation.Viewmodels.Settings
{
    public partial class SettingPageViewModel : BaseViewModel
    {
        #region Commands
        public ICommand NavigateToMetalTypePageCommnad => new Command(async () => await NavigateToMetalTypePageAsync());
        public ICommand LogoutPageCommnad => new Command(SettingPageViewModel.LogoutAsync);

        #endregion

        #region Constructor and init Functions
        public SettingPageViewModel(IDataService localDataService, INavigationService navigationservice) : base(localDataService, navigationservice)
        {
        }
        public static async Task OnAppearing()
        {
            await Task.CompletedTask;
        }
        #endregion

        #region Methods
        public static async void LogoutAsync()
        {
            await Task.Delay(2000);
            Application.Current.MainPage = new AuthPage();
        }

        public async Task NavigateToMetalTypePageAsync()
        {
            await _navigationService.NavigateToAsync(NavigationPath.MetalTypePage);
        }
        #endregion
    }
}
