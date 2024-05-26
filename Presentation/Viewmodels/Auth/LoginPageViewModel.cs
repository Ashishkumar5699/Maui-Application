using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using Punjab_Ornaments.Infrastructure.Database;
using Punjab_Ornaments.Infrastructure.Navigation;
using System.Windows.Input;

namespace Punjab_Ornaments.Presentation.Viewmodels.Auth
{
    public class LoginPageViewModel : BaseViewModel
    {
        private string _username;
        private string _password;

        public LoginPageViewModel(IDataService localDataService, INavigationService navigationservice) : base(localDataService, navigationservice)
        {
            LoginCommand = new Command(async () => await LoginAction());
        }

        public ICommand LoginCommand { get; }

        public string UserName
        {
            get => _username;
            set => _username = value;
        }

        public string Password
        {
            get => _password;
            set => _password = value;
        }

        private async Task LoginAction()
        {
            var isAuthorized = await _dataService.LoginUser(UserName, Password);

            if (isAuthorized.Data != null && isAuthorized.Data.IsUserloggedin)
            {
                Application.Current.MainPage = new AppShell();
            }
        }
    }
}
