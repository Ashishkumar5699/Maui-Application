using Sonaar.Presentation.Viewmodels;

namespace Sonaar.Presentation.Views;

public partial class StockView : ContentPage
{
	public StockView(StockViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;

    }
}