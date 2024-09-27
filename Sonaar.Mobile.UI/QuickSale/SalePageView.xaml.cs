using CustomControlFramework.Page;

namespace Sonaar.Mobile.UI.QuickSale;

public partial class SalePageView : ContentPageMobileBase
{
	public SalePageView(SalePageViewModel viewModel)
	{
        try
        {
		    InitializeComponent();
		    BindingContext = viewModel;
        }
        catch (Exception ex)
        {

        }
    }


    protected override void OnAppearing()
    {
        base.OnAppearing();
        var vm = BindingContext as SalePageViewModel;
        vm.InitializeAsync();
    }
}
