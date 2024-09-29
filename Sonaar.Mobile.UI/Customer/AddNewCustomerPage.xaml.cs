namespace Sonaar.Mobile.UI.Customer;

using CustomControlFramework.Page;

public partial class AddNewCustomerPage : ContentPageMobileBase
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
