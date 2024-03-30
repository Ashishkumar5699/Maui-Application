using Punjab_Ornaments.Presentation.Viewmodels;

namespace Punjab_Ornaments.Presentation.Views;

public partial class AddGoldStock : ContentPage
{
    public AddGoldStock(GoldStockListViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}