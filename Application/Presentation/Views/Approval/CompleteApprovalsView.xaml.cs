using Sonaar.Presentation.Viewmodels.Approval;

namespace Sonaar.Presentation.Views.Approval;

public partial class CompleteApprovalsView : ContentPage
{
	public CompleteApprovalsView(CompleteApprovalViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        var vm = BindingContext as CompleteApprovalViewModel;
        await vm.OnAppearing();
    }
}