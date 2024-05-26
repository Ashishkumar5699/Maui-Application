using Punjab_Ornaments.Presentation.Viewmodels.Settings;

namespace Punjab_Ornaments.Presentation.Views.Settings;

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