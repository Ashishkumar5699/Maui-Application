using Sonaar.Presentation.Viewmodels;

namespace Sonaar.Presentation.Views;

public partial class GoldStockDetailPage : ContentPage
{
	public GoldStockDetailPage(GoldStockDetailPageViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
    }

    //protected override async void OnAppearing()
    //{
    //    base.OnAppearing();
    //    var vm = BindingContext as GoldStockDetailPageViewModel;
    //    await vm.OnAppearing();
    //}
}