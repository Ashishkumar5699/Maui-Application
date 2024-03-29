using Punjab_Ornaments.Presentation.Viewmodels.Auth;
using Punjab_Ornaments.Presentation.Viewmodels.Common;

namespace Punjab_Ornaments.Presentation.Views.Auth;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
		try
		{
			InitializeComponent();
			BindingContext = ServiceHelper.GetService<LoginPageViewModel>();
		}
		catch (Exception ex)
		{

		}
	}
}