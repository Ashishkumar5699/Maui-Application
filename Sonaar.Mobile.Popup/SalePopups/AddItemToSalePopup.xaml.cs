using Sonaar.Mobile.Models.Sale;
using Sonaar.Mobile.Popup.Common;

namespace Sonaar.Mobile.Popup.SalePopups;

public partial class AddItemToSalePopup : PopupView
{
    private readonly AddItemToSalePopupViewModel vm;

    public AddItemToSalePopup(AddItemToSalePopupViewModel viewModel)
	{
        InitializeComponent();
		BindingContext = vm = viewModel;
    }

    void Add_Button_Clicked(System.Object sender, System.EventArgs e)
    {
        Close(vm.SaleItem);
    }

    void Close_Button_Clicked(System.Object sender, System.EventArgs e)
    {
        Close();
    }
}