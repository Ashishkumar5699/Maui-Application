using Sonaar.Mobile.Models.Client;
using Sonaar.Mobile.Models.Products;
using Sonaar.Mobile.Models.Sale;
using Sonaar.Mobile.Models.Tax;

namespace Sonaar.Mobile.Models.Prints
{
	public class PrintBillModel
	{
        public int Billid { get; set; }

        public Consumer Consumer { get; set; }

        public List<SaleModel> ProductList { get; set; }

        public GSTAmount GSTAmount { get; set; }
    }
}

