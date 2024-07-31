namespace Sonaar.Mobile.UI.QuickSale;

public partial class SalePageView : ContentPage
{
	public SalePageView(SalePageViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
    }


    protected override void OnAppearing()
    {
        base.OnAppearing();
        var vm = BindingContext as SalePageViewModel;
        vm.InitializeAsync();
    }
}
