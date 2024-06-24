using Sonaar.Presentation.Viewmodels.QuickSale;

namespace Sonaar.Presentation.Views.QuickSale;

public partial class SalePageView : ContentPage
{
	public SalePageView(SalePageViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
    }
}
