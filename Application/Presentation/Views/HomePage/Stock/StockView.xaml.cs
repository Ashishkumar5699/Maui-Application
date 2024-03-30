using Punjab_Ornaments.Presentation.Viewmodels;

namespace Punjab_Ornaments.Presentation.Views;

public partial class StockView : ContentPage
{
	public StockView(StockViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;

    }
}