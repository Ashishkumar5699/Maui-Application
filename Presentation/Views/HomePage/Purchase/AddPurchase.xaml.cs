using Punjab_Ornaments.Presentation.Viewmodels.HomePage.Purchase;

namespace Punjab_Ornaments.Presentation.Views.Purchase;

public partial class AddPurchase : ContentPage
{
	public AddPurchase(AddPurchaseViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
    }
    protected override void OnAppearing()
    {
        base.OnAppearing();
        var vm = BindingContext as AddPurchaseViewModel;
        vm.OnAppearing();
    }
    private void Entry_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
        var vm = BindingContext as AddPurchaseViewModel;
        vm?.UpdateWeight();
    }
}