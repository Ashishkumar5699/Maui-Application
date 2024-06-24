using Sonaar.Presentation.Viewmodels.Approval;

namespace Sonaar.Presentation.Views.Approval;

public partial class PurchaseDetailPage : ContentPage
{
	public PurchaseDetailPage(PurchaseDetailViewModel viewmodel)
	{
		InitializeComponent();
		BindingContext = viewmodel;
	}
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        var vm = BindingContext as PurchaseDetailViewModel;
        await vm.OnAppearing();
    }
}