using Punjab_Ornaments.Presentation.Viewmodels.Settings;

namespace Punjab_Ornaments.Presentation.Views.Settings;

public partial class SettingPage : ContentPage
{
	public SettingPage(SettingPageViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        var vm = BindingContext as SettingPageViewModel;
        await SettingPageViewModel.OnAppearing();
    }
}