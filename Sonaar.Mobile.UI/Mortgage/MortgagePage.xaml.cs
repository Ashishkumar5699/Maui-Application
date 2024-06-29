namespace Sonaar.Mobile.UI.Mortgage;

public partial class MortgagePage : ContentPage
{
	public MortgagePage(MortgageViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}
