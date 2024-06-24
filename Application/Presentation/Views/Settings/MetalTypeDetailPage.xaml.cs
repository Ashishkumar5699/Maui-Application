using Sonaar.Presentation.Viewmodels.Settings;

namespace Sonaar.Presentation.Views.Settings;

public partial class MetalTypeDetailPage : ContentPage
{
	public MetalTypeDetailPage(MetalTypeDetailPageViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        var vm = BindingContext as MetalTypeDetailPageViewModel;
        await vm.OnAppearing();
    }
}