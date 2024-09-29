using CustomControlFramework.Page;

namespace Sonaar.Mobile.UI.QuickSale.SaleSection;

public partial class PendingSalePage : ContentPageMobileBase
{
	private readonly PendingSalePageViewModel viewModel;

    public PendingSalePage(PendingSalePageViewModel pendingSale)
	{
		InitializeComponent();
        BindingContext = viewModel = pendingSale;
    }
}
