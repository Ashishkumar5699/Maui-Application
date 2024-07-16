using System;
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
        public decimal totalAfterDiscount;

        [ObservableProperty]
        public decimal cGSt;

        [ObservableProperty]
        public decimal sGST;

        [ObservableProperty]
        public decimal iGST;

        [ObservableProperty]
        public decimal grandTotal;
    }
}

