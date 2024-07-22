using Punjab_Ornaments.Presentation.Viewmodels;
using Sonaar.Infrastructure.Database;
using Sonaar.Infrastructure.Navigation;
using System.Windows.Input;

namespace Sonaar.Presentation.Viewmodels.Auth
{
    public class LoginPageViewModel : BaseViewModel
    {
        private string _username;
        private string _password;

        private readonly IDataService _dataService;

        public LoginPageViewModel(INavigationService navigationService, IDataService dataService) : base(navigationService)
        {
            _dataService = dataService;
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

            if (isAuthorized.Data != null && !string.IsNullOrEmpty(isAuthorized.Data.Token))
            {
                Application.Current.MainPage = new AppShell();
            }
        }
    }
}
