using Punjab_Ornaments.Infrastructure.APIService;
using Punjab_Ornaments.Infrastructure.Database;
using Punjab_Ornaments.Infrastructure.Navigation;
using Punjab_Ornaments.Presentation.Views.Auth;
using Punjab_Ornaments.Resources.Constant;
using System.Windows.Input;

namespace Punjab_Ornaments.Presentation.Viewmodels.Settings
{
    public partial class SettingPageViewModel : BaseViewModel
    {
        #region Commands
        public ICommand NavigateToMetalTypePageCommnad => new Command(async () => await NavigateToMetalTypePageAsync());
        public ICommand LogoutPageCommnad => new Command(LogoutAsync);

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
        public async void LogoutAsync()
        {
            await Task.Delay(2000);
            Application.Current.MainPage = new LoginPage();
        }

        public async Task NavigateToMetalTypePageAsync()
        {
            await _navigationService.NavigateToAsync(NavigationPath.MetalTypePage);
        }
        #endregion
    }
}
