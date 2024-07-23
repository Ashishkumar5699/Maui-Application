using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using Sonaar.Mobile.Services.Navigation;
using Sonaar.Mobile.UI.Common;
using Sonaar.Mobile.Models.Client;
using Sonaar.Mobile.Models.Tax;
using Sonaar.Mobile.Models.Sale;
using Sonaar.Mobile.Models.Prints;
//using Sonaar.Mobile.Models.Products;
using Sonaar.Mobile.Services.PrintService;
using CommunityToolkit.Mvvm.Input;
using Sonar.Mobile.Platform.FileService;
using System.ComponentModel;

namespace Sonaar.Mobile.UI.QuickSale
{
    public partial class SalePageViewModel : BaseViewModel, INotifyPropertyChanged
    {
        #region Private Members

        private readonly IPrintService _printService;

        private ObservableCollection<SaleModel> _saleItems;
        private GSTAmountModel _amountModel;

        #endregion

        #region Constructor and InitializeAsync

        public SalePageViewModel(INavigationService navigationService, IPrintService printService) : base(navigationService)
        {
            _printService = printService;

            CustmorDetail = new Consumer
            {
                CustmorPrifix = "mr",
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

            //AmountModel = new GSTAmountModel
            //{
            //    Discount = 0,
            //    TotalAfterDiscount = 0,
            //    CGSt = (decimal)0,
            //    IGST = (decimal)0,
            //    GrandTotal = (decimal)0,
            //};

            SaleItems = new ObservableCollection<SaleModel>();
            SaleItems.Add(new SaleModel
            {
                Id = SaleItems.Count + 1
            });

            //InitializeAsync();
        }

        public override Task InitializeAsync(object obj = null)
        {
            //AddNewIteminSales();
            return base.InitializeAsync(obj);
        }

        #endregion

        #region Commands

        //TODO : check it was used or not;
        [RelayCommand]
        private void UpdateAction(int id)
        {
            decimal amount = 0;
            foreach (var item in SaleItems)
            {
                //if (item.Id == id)
                //    item.Amount = (item.Rate + item.Making_Charge) * item.Weight;

                amount += item.Amount;
            }
            //AmountModel.Total = amount;
            OnPropertyChanged(nameof(SaleItems));
            OnPropertyChanged(nameof(AmountModel));

        }

        [RelayCommand]
        private void AddNewIteminSales()
        {
            SaleItems.Add(new SaleModel
            {
                Id = SaleItems.Count + 1,
                Description = NewSaleItem.Description,
                HSN_Code = NewSaleItem.HSN_Code,
                Purity = NewSaleItem.Purity,
                Weight = NewSaleItem.Weight,
                Rate = NewSaleItem.Rate,
                Making_Charge = NewSaleItem.Making_Charge,
                //Amount = NewSaleItem.Amount,
            });

            NewSaleItem = new SaleModel();
            ShowPopup = false;
        }

        [RelayCommand]
        private void AddNewItemPopupSales()
        {
            ShowPopup = true;
            NewSaleItem = new SaleModel();
        }

        [RelayCommand]
        private async Task GenerateBill()
        {
            var billmodel = new PrintBillModel
            {
                Consumer = CustmorDetail,

                ProductList = new List<SaleModel>(SaleItems),

                //GSTAmount = new GSTAmount
                //{
                //    Discount = AmountModel.Discount,
                //    TotalAfterDiscount = AmountModel.TotalAfterDiscount,
                //    CGSt = AmountModel.CGSt,
                //    SGST = AmountModel.SGST,
                //    IGST = AmountModel.IGST,
                //    GrandTotal = AmountModel.GrandTotal,
                //}
            };

            var abc = await _printService.GenerateQuotation(billmodel);
            var file = new SaveService();
            var mc = new MemoryStream(abc.Data);
            file.SaveAndView("test.pdf", "Application/pdf", mc);
        }


        #endregion

        #region HelperFunctions
        
        private void UpdateGSTAmount()
        {
            if (_amountModel != null)
            {
                //_amountModel.TotalAfterDiscount = _amountModel.Total - _amountModel.Discount;
                //_amountModel.CGSt = (_amountModel.TotalAfterDiscount * (decimal)1.5) /100;
                //_amountModel.SGST = (_amountModel.TotalAfterDiscount * (decimal)1.5) / 100;
                //_amountModel.GrandTotal = _amountModel.TotalAfterDiscount + _amountModel.CGSt + _amountModel.SGST;
            }
        }

        private void CalculateTotalAmount()
        {
            decimal _total = 0;

            SaleItems ??= new ObservableCollection<SaleModel>();

            foreach (var item in SaleItems)
            {
                _total += item.Amount;
            }

            //AmountModel.GrandTotal = _total;
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
            set
            {
                UpdateGSTAmount();
                SetProperty(ref _amountModel, value);
            }
        }

        public ObservableCollection<SaleModel> SaleItems
        {
            get => _saleItems;
            set
            {
                if(_saleItems != value)
                {
                    SetProperty(ref _saleItems, value);
                    CalculateTotalAmount();
                }
            }
        }

        [ObservableProperty]
        bool showPopup;
        #endregion

    }
}
