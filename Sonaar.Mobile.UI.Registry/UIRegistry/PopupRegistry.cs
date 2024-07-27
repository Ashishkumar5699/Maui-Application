using CommunityToolkit.Maui;

namespace Sonaar.Mobile.UI.Registry.UIRegistry
{
	public static class PopupRegistry
	{
        public static MauiAppBuilder RegisterPopups(this MauiAppBuilder mauiAppBuilder)
        {
            mauiAppBuilder.Services.AddTransientPopup<Popup.SalePopups.AddItemToSalePopup, Popup.SalePopups.AddItemToSalePopupViewModel>();

            return mauiAppBuilder;
        }
    }
}

