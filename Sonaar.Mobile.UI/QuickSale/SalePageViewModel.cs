using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using Sonaar.Mobile.Services.Navigation;
using Sonaar.Mobile.UI.Common;
using Sonaar.Mobile.Models.Client;
using Sonaar.Mobile.Models.Tax;
using Sonaar.Mobile.Models.Sale;
using Sonaar.Mobile.Services.PrintService;
using CommunityToolkit.Mvvm.Input;
using Sonaar.Mobile.Services.PopupService;
using Sonaar.Mobile.Models.QuickSale;

namespace Sonaar.Mobile.UI.QuickSale
{
    public partial class SalePageViewModel : BaseViewModel
    {
        #region Private Members

        private readonly IPrintService _printService;
        private readonly ISalePopupService _salePopupService;

        private ObservableCollection<SaleModel> _saleItems;
        private GSTAmountModel _amountModel;

        #endregion

        #region Constructor and InitializeAsync

        public SalePageViewModel(INavigationService navigationService, IPrintService printService, ISalePopupService salePopupService) : base(navigationService)
        {
            _printService = printService;
            _salePopupService = salePopupService;

            CustmorDetail = new Consumer();
            SaleItems = new ObservableCollection<SaleModel>();
            AmountModel = new GSTAmountModel();
        }

        #endregion

        #region Commands

        [RelayCommand]
        private async Task AddNewItemPopupSales(SaleModel sale)
        {
            var saleItem = new SaleModel
            {
                Id = SaleItems.Count + 1,
            };

            if (sale != null)
            {
                saleItem.Id = sale.Id;
                saleItem.Description = sale.Description;
                saleItem.HSN_Code = sale.HSN_Code;
                saleItem.Purity = sale.Purity;
                saleItem.Weight = sale.Weight;
                saleItem.Rate = sale.Rate;
                saleItem.Making_Charge = sale.Making_Charge;
                saleItem.IsExisting = true;
            }

            var result = await _salePopupService.ShowClientMessage(saleItem);
            if (result != null)
            {
                SaleItems.Add(result);

                CalculateGSTAmount();
            }
        }

        [RelayCommand]
        private void RemoveItemSales(SaleModel sale)
        {
            SaleItems.Remove(sale);
        }

        [RelayCommand]
        private async Task GenerateBill()
        {
            var billmodel = new PrintBillModel
            {
                Consumer = CustmorDetail,
                DateofBill = DateTime.Today,
                BillType = Domain.Enum.BillType.Quotation,
                ProductList = new List<SaleModel>(SaleItems),
                GSTAmount = AmountModel,
                //FirmDetail = new Domain.Models.Company.FirmDetail
                //{
                //    FirmName = "FirmName",
                //    FirmAddress = "FirmAddress",
                //    FirmGSTNumber = "FirmGSTNumber",
                //    FirmPhoneNumber = "FirmPhoneNumber",
                //},

            };

            var abc = await _printService.GenerateQuotation(billmodel);
            if (abc.Data != null)
            {
                var file = new PlatformService.FileService.SaveService();
                var mc = new MemoryStream(abc.Data);
                file.SaveAndView("test.pdf", "Application/pdf", mc);
            }
        }


        #endregion

        #region Helper Functions

        private string CalculateGSTAmount()
        {
            AmountModel.Total = CalculateTotalWithoutGST();
            AmountModel.Discount = Discount;
            AmountModel.TotalAfterDiscount = AmountModel.Total - AmountModel.Discount;

            AmountModel.CGSt = AmountModel.SGST = AmountModel.TotalAfterDiscount * (decimal)1.5 / 100;

            AmountModel.GrandTotal = AmountModel.TotalAfterDiscount + AmountModel.CGSt + AmountModel.SGST;

            return null;
        }

        private decimal CalculateTotalWithoutGST()
        {

            var total = SaleItems.Sum(x => x.Amount);

            return total;
        }

        #endregion

        #region Bindbale Properties

        [ObservableProperty]
        Consumer custmorDetail;

        [ObservableProperty]
        SaleModel newSaleItem;

        public GSTAmountModel AmountModel
        {
            get => _amountModel;
            set => SetProperty(ref _amountModel, value);
        }

        public ObservableCollection<SaleModel> SaleItems
        {
            get => _saleItems;
            set
            {
                if (_saleItems != value)
                {
                    SetProperty(ref _saleItems, value);
                    //CalculateTotalAmount();
                }
            }
        }

        private decimal _discount;
        public decimal Discount
        {
            get => _discount;
            set
            {
                SetProperty(ref _discount, value);
                CalculateGSTAmount();
            }
        }
        #endregion

    }
}
