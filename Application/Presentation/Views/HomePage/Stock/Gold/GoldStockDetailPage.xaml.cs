using Punjab_Ornaments.Presentation.Viewmodels;

namespace Punjab_Ornaments.Presentation.Views;

public partial class GoldStockDetailPage : ContentPage
{
	public GoldStockDetailPage(GoldStockDetailPageViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        var vm = BindingContext as GoldStockDetailPageViewModel;
        await vm.OnAppearing();
    }
}