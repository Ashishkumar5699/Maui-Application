using System.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel;
using Sonaar.Mobile.Models.Sale;

namespace Sonaar.Mobile.Popup.SalePopups
{
	public partial class AddItemToSalePopupViewModel : ObservableObject, INotifyPropertyChanged
	{
        public AddItemToSalePopupViewModel(SaleModel? saleModel = null)
        {
            SaleItem = saleModel ?? new SaleModel();
        }
        //[ObservableProperty]
        private SaleModel saleItem;
        public SaleModel SaleItem
        {
            get => saleItem;
            set => SetProperty(ref saleItem, value);
        }
    }
}