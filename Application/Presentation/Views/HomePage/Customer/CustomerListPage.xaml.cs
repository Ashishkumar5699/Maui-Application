using Punjab_Ornaments.Presentation.Viewmodels.HomePage.Customer;

namespace Punjab_Ornaments.Presentation.Views.Customer;

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