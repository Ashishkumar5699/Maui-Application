using Sonaar.Presentation.Viewmodels.Approval;

namespace Sonaar.Presentation.Views.Approval;

public partial class PendingApprovalsView : ContentPage
{
	public PendingApprovalsView(PendingApprovalsViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        var vm = BindingContext as PendingApprovalsViewModel;
        await vm.OnAppearing();
    }
}