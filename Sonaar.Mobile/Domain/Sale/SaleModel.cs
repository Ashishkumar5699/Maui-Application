using System;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Sonaar.Domain.Sale
{
	public partial class SaleModel : Sonaar.Common.Bills.ProductModel
    {
		public int Id { get; set; }

		public ICommand AmountUpdateCommand { get; set; }

    }
}

