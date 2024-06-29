using Sonaar.Presentation.Viewmodels.HomePage.Customer;

namespace Sonaar.Presentation.Views.Customer;

public partial class CustomerListPage : ContentPage
{
	public CustomerListPage(CustomerListViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        var vm = BindingContext as CustomerListViewModel;
        await vm.OnAppearing();
    }
}