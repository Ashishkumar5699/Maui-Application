using Punjab_Ornaments.Presentation.Viewmodels.HomePage.Customer;

namespace Punjab_Ornaments.Presentation.Views;

public partial class AddNewCustomerPage : ContentPage
{
	public AddNewCustomerPage(AddNewCustomerPageViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;

    }
}