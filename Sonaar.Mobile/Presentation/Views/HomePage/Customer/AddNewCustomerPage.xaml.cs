using Sonaar.Presentation.Viewmodels.HomePage.Customer;

namespace Sonaar.Presentation.Views;

public partial class AddNewCustomerPage : ContentPage
{
	public AddNewCustomerPage(AddNewCustomerPageViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;

    }
}