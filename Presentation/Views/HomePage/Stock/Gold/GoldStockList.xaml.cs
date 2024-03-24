using Punjab_Ornaments.Presentation.Viewmodels;

namespace Punjab_Ornaments.Presentation.Views;

public partial class GoldStockList : ContentPage
{
    public GoldStockList(GoldStockListViewModel viewModel)
	{
        InitializeComponent();
		BindingContext = viewModel;
	}
    protected override async void OnAppearing()
	{
		base.OnAppearing();
		var vm = BindingContext as GoldStockListViewModel;
		await vm.OnAppearing();
	}

    private void Copy_text(object sender, TappedEventArgs e)
    {
		var copiedtest = (sender as Label).Text;
		Clipboard.SetTextAsync(copiedtest);
    }
}