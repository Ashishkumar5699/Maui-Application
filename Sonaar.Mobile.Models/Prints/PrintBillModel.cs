using Sonaar.Domain.Bills;
using Sonaar.Domain.Models.Bills;
using Sonaar.Mobile.Models.Client;
using Sonaar.Mobile.Models.Company;
using Sonaar.Mobile.Models.Sale;
using Sonaar.Mobile.Models.Tax;

namespace Sonaar.Mobile.Models.Prints
{
    public class PrintBillModel
	{
        public int Billid { get; set; }

        public required DateTime DateofBill { get; set; }

        public required BillTypeEnum BillType { get; set; }

        public Consumer Consumer { get; set; }

        public List<SaleModel> ProductList { get; set; }

        public GSTAmountModel GSTAmount { get; set; }

        public FirmDetail FirmDetail { get; set; }

        //public int Billid { get; set; }

        //public required Consumer Consumer { get; set; }

        //public required List<ProductModel> ProductList { get; set; }

        //public required GSTAmount GSTAmount { get; set; }

        //public required FirmDetail FirmDetail { get; set; }
    }
}

