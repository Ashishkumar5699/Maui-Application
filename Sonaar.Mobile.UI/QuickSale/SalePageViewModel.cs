using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using Sonaar.Mobile.Services.Navigation;
using Sonaar.Mobile.UI.Common;
using Sonaar.Mobile.Models.Tax;
using Sonaar.Mobile.Models.Sale;
using Sonaar.Mobile.Services.PrintService;
using CommunityToolkit.Mvvm.Input;
using Sonaar.Mobile.Services.PopupService;
using Sonaar.Mobile.Models.QuickSale;
using CommunityToolkit.Mvvm.Messaging;
using Sonaar.Mobile.Services.CustomerService;

namespace Sonaar.Mobile.UI.QuickSale
{
    public partial class SalePageViewModel : BaseViewModel
    {
        #region Private Members

        private readonly IPrintService _printService;
        private readonly ISalePopupService _salePopupService;
        private readonly ICustomerService _customerService;

        private ObservableCollection<SaleModel> _saleItems;
        private GSTAmountModel _amountModel;

        #endregion

        #region Constructor and InitializeAsync

        public SalePageViewModel(INavigationService navigationService, IPrintService printService, ISalePopupService salePopupService,ICustomerService customerService) : base(navigationService)
        {
            _printService = printService;
            _salePopupService = salePopupService;
            _customerService = customerService;

            // CustmorDetail = new Sonaar.Mobile.Models.Client.Customer();
            SaleItems = new ObservableCollection<SaleModel>();
            AmountModel = new GSTAmountModel();
        }

        #endregion

        #region Commands

        [RelayCommand]
        private async Task AddNewItemPopupSales(SaleModel sale)
        {
            var saleItem = new SaleModel();

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
                result.Id = SaleItems.Count + 1;

                SaleItems.Add(result);

                CalculateGSTAmount();
                CheckCondition2();
            }
        }

        [RelayCommand]
        private void RemoveItemSales(SaleModel sale)
        {
            SaleItems.Remove(sale);
            CheckCondition2();
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
            };

            var abc = await _printService.GenerateQuotation(billmodel);
            if (abc.Data != null)
            {
                var file = new PlatformService.FileService.SaveService();
                var mc = new MemoryStream(abc.Data);
                file.SaveAndView("test.pdf", "Application/pdf", mc);
            }
        }

        [RelayCommand]
        private async Task AddNewContact()
        {
            await _navigationService.NavigateToAsync(NavigationPath.AddNewCustomerPage);
        }

        [RelayCommand]
        private async Task LoadCustmor(string phone)
        {
            try
            {
                if(phone.Length == 10)
                {
                    IsBusy = true;
                    if (long.TryParse(phone,out var PhoneNumber))
                    {
                        var cusmor = await _customerService.GetCustomerByPhone(PhoneNumber);
                        if(Condition1 = cusmor != null)
                        {
                            CustmorDetail = cusmor;
                            UpdateProgress();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _ = Application.Current.MainPage.DisplayAlert("Error", ex.ToString(), "ok");
            }
            finally
            {
                IsBusy = false;
            }
        }

        [RelayCommand]
        private void ResetCustmor()
        {
            CustmorDetail = null;
            Condition1 = false;
            UpdateProgress();
        }

        private void UpdateProgress()
        {
            Progress = (Condition1 ? 0.25 : 0) + (Condition2 ? 0.25 : 0) + (Condition3 ? 0.25 : 0) + (Condition4 ? 0.25 : 0);
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

        private void CheckCondition2()
        {
            Condition2 = SaleItems.Any();
            UpdateProgress();
        }

        #endregion

        #region Bindbale Properties

        [ObservableProperty]
        Models.Client.Customer custmorDetail;

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

        [ObservableProperty]
        private bool condition1 = false;//add contact

        [ObservableProperty]
        private bool condition2;//add itemtoSale

        [ObservableProperty]
        private bool condition3;//add saler signatue

        [ObservableProperty]
        private bool condition4;//add custmore signature

        #endregion

    }
}
