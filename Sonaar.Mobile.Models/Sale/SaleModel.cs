using System;
using System.Windows.Input;

namespace Sonaar.Mobile.Models.Sale
{
	public class SaleModel
	{
        public int Id { get; set; }

        public ICommand AmountUpdateCommand { get; set; }

        public string Description { get; set; }

        public string HSN_Code { get; set; }

        public string Purity { get; set; }

        public decimal Weight { get; set; }

        public decimal Rate { get; set; }

        public decimal Making_Charge { get; set; }

        public decimal Amount { get; set; }
    }
}

