using Sonaar.Presentation.Viewmodels;

namespace Sonaar.Presentation.Views;

public partial class HomePageView : ContentPage
{
	public HomePageView(HomePageViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}