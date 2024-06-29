using Sonaar.Presentation.Viewmodels;

namespace Sonaar.Presentation.Views;

public partial class AddGoldStock : ContentPage
{
    public AddGoldStock(GoldStockListViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}