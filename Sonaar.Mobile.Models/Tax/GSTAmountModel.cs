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

        public decimal TotalAfterDiscount => Total - Discount;

        public decimal CGSt => TotalAfterDiscount * (decimal)1.5 / 100;

        public decimal SGST => TotalAfterDiscount * (decimal)1.5 / 100;

        public decimal IGST => TotalAfterDiscount * 3 / 100;

        public decimal GrandTotal => TotalAfterDiscount + CGSt + SGST;
    }
}

