using CustomControlFramework.Page;

namespace Sonaar.Mobile.UI.Customer;

public partial class CustomerListPage : ContentPageMobileBase
{
	private readonly CustomerListPageViewModel customerListViewModel;

	public CustomerListPage(CustomerListPageViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = customerListViewModel = viewModel;
	}

    protected override async void OnAppearing()
    {
        base.OnAppearing();
	 	await customerListViewModel.InitializeAsync();
    }
}
