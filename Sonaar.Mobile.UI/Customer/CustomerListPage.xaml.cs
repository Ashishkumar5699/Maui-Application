namespace Sonaar.Mobile.UI.Customer;

public partial class CustomerListPage : ContentPage
{
	private readonly CustomerListPageViewModel customerList;
	public CustomerListPage(CustomerListPageViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = customerList = viewModel;
	}
}
