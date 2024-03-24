using Punjab_Ornaments.Presentation.Viewmodels;

namespace Punjab_Ornaments.Presentation.Views;

public partial class HomePageView : ContentPage
{
	public HomePageView(HomePageViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}