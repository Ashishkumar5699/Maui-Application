using Punjab_Ornaments.Presentation.Viewmodels.QuickSale;

namespace Punjab_Ornaments.Presentation.Views.QuickSale;

public partial class SalePageView : ContentPage
{
	public SalePageView(SalePageViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
    }
}
