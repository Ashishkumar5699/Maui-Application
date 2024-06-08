using System;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Punjab_Ornaments.Domain.Sale
{
	public partial class SaleModel : PunjabOrnaments.Common.Bills.ProductModel
    {
		public int Id { get; set; }

		public ICommand AmountUpdateCommand { get; set; }

    }
}

