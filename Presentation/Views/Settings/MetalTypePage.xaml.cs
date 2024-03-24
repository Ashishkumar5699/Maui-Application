using Punjab_Ornaments.Presentation.Viewmodels.Settings;

namespace Punjab_Ornaments.Presentation.Views.Settings;

public partial class MetalTypePage : ContentPage
{
	public MetalTypePage(MetalTypePageViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        var vm = BindingContext as MetalTypePageViewModel;
        await vm.OnAppearing();
    }
}