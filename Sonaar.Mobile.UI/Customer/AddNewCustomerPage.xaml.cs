namespace Sonaar.Mobile.UI.Customer;
using Microsoft.Extensions.Logging;

public partial class AddNewCustomerPage : ContentPage
{
    private readonly AddNewCustomerPageViewModel addNewCustomerPageViewModel;

    public AddNewCustomerPage(AddNewCustomerPageViewModel viewModel)
	{
        InitializeComponent();
        BindingContext = addNewCustomerPageViewModel = viewModel;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await addNewCustomerPageViewModel.InitializeAsync();
    }
}
