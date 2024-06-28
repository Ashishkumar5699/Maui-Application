namespace Sonaar.Mobile.UI.QuickSale;

public partial class SalePageView : ContentPage
{
	public SalePageView(SalePageViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;

    }
}
