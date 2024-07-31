using CommunityToolkit.Mvvm.ComponentModel;

namespace Sonaar.Mobile.Models.Tax
{
	public partial class GSTAmountModel : ObservableObject
    {
        [ObservableProperty]
        decimal total;

        [ObservableProperty]
        decimal discount;

        [ObservableProperty]
        decimal totalAfterDiscount;

        [ObservableProperty]
        decimal cGSt;

        [ObservableProperty]
        decimal sGST;

        [ObservableProperty]
        decimal iGST;

        [ObservableProperty]
        decimal grandTotal;
    }
}

