using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using Sonaar.Mobile.Services.Navigation;
using Sonaar.Mobile.UI.Common;
using Sonaar.Mobile.Models.Client;
using Sonaar.Mobile.Models.Tax;
using Sonaar.Mobile.Models.Sale;
using Sonaar.Mobile.Models.Prints;
using Sonaar.Mobile.Models.Products;
using Sonaar.Mobile.Services.PrintService;
using CommunityToolkit.Mvvm.Input;
using Sonaar.Mobile.Services.SaveService;

namespace Sonaar.Mobile.UI.QuickSale
{
    public partial class SalePageViewModel : BaseViewModel
    {
        #region Private Members

        private readonly IPrintService _printService;

        #endregion

        #region Constructor and InitializeAsync

        public SalePageViewModel(INavigationService navigationService, IPrintService printService) : base(navigationService)
        {
            _printService = printService;

            SaleItems = new ObservableCollection<SaleModel>();

            InitializeAsync();
        }

        public void InitializeAsync()
        {
            AddNewIteminSales();
        }

        #endregion

        #region Commands

        [RelayCommand]
        private void UpdateAction(int id)
        {
            decimal amount = 0;
            foreach (var item in SaleItems)
            {
                if (item.Id == id)
                    item.Amount = (item.Rate + item.Making_Charge) * item.Weight;

                amount += item.Amount;
            }
            AmountModel.Total = amount;
            OnPropertyChanged(nameof(SaleItems));
            OnPropertyChanged(nameof(AmountModel));

        }

        [RelayCommand]
        private async Task GenerateBill()
        {
            var billmodel = new PrintBillModel();
            billmodel.Consumer = new Consumer
            {
                CustmorPrifix = "MR",
                CustmorFirstName = "CustmorFirstName",
                CustmorLastName = "CustmorLastName",
                CustmorPhoneNumber = "CustmorPhoneNumber",
                CustmorAddress1 = "CustmorAddress1",
                CustmorAddress2 = "CustmorAddress2",
                CustmorLandMark = "CustmorLandMark",
                CustmorCity = "CustmorCity",
                CustmorState = "CustmorState",
                CustmorPinCode = "CustmorPinCode",
            };

            billmodel.ProductList = new List<ProductModel>
            {
                new ProductModel
                {
                    Description = "Description",
                    HSN_Code = "HSN_Code",
                    Purity = "Purity",
                    Weight = 1,
                    Rate = 100,
                    Making_Charge = 10,
                    Amount = 110,
                }
            };
            billmodel.GSTAmount = new GSTAmount
            {
                Discount = 0,
                TotalAfterDiscount = 110,
                CGSt = (decimal)1.65,
                IGST = (decimal)1.65,
                GrandTotal = (decimal)113.3,
            };

            var abc = await _printService.GenerateQuotation(billmodel);
            var file = new SaveService();
            var mc = new MemoryStream(abc.Data);
            file.SaveAndView("test.pdf", "Application/pdf", mc);
        }


        #endregion

        #region HelperFunctions

        private void AddNewIteminSales()
        {
            SaleItems.Add(new SaleModel
            {
                Id = SaleItems.Count + 1,
                AmountUpdateCommand = UpdateActionCommand
            });
        }

        #endregion

        #region Bindbale Properties

        [ObservableProperty]
        Customer custmorDetail;

        [ObservableProperty]
        GSTAmountModel amountModel;

        [ObservableProperty]
        ObservableCollection<SaleModel> saleItems;

        #endregion

    }
}
