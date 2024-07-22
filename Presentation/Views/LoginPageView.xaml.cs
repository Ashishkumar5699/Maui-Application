using Punjab_Ornaments.Infrastructure.ServiceHelper;
using Sonaar.Presentation.Viewmodels.Auth;

namespace Punjab_Ornaments.Presentation.Views;

public partial class LoginPageView : ContentPage
{
	public LoginPageView()
	{
		InitializeComponent();
        BindingContext = ServiceHelper.GetService<LoginPageViewModel>();
    }
}
