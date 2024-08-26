using System;
using Sonaar.Mobile.Models.Client;
using Sonaar.Mobile.Models.Sale;
using Sonaar.Mobile.Models.Tax;
using Linker = Sonaar.Domain;

namespace Sonaar.Mobile.Models.QuickSale
{
	public class PrintBillModel
	{
        public int Billid { get; set; }

        public Linker.Enum.BillType BillType { get; set; }

        public DateTime DateofBill { get; set; }

        public Linker.Models.Company.FirmDetail FirmDetail { get; set; }

        public required Customer Consumer { get; set; }

        public required List<SaleModel> ProductList { get; set; }

        public required GSTAmountModel GSTAmount { get; set; }
    }
}

