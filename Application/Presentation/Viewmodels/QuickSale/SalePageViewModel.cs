using System.Collections.ObjectModel;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using Sonaar.Infrastructure.Database;
using Sonaar.Infrastructure.Navigation;
using Sonaar.Domain.Sale;
using Sonaar.Domain.Customer;
using Sonaar.Common.Bills;
using Sonaar.Infrastructure.Helpers;

namespace Sonaar.Presentation.Viewmodels.QuickSale
{
    public partial class SalePageViewModel : BaseViewModel
    {

        public SalePageViewModel(IDataService localDataService, INavigationService navigationService) : base(localDataService, navigationService)
        {
            AmountModel = new GSTAmountModel();
            SaleItems = new ObservableCollection<SaleModel>();

            UpdateCommand = new Command<int>(UpdateAction);
            GenerateBillCommand = new Command(GenerateBillAsync);
            AddNewIteminSalesCommand = new Command(AddNewIteminSales);

            InitializeAsync();
        }

        #region Commands
        public ICommand UpdateCommand { get; }

        public ICommand GenerateBillCommand { get; }

        public ICommand AddNewIteminSalesCommand { get; }
        #endregion

        private void InitializeAsync()
        {
            //for (int i = 1; i <= 5; i++)
            //{
            AddNewIteminSales();
            //}
        }

        private void AddNewIteminSales()
        {
            SaleItems.Add(new SaleModel
            {
                Id = SaleItems.Count + 1,
                AmountUpdateCommand = UpdateCommand
            });
        }

        private async void GenerateBillAsync()
        {
            var billmodel = new PrintBillModel();
            billmodel.Consumer = new Sonaar.Common.Models.Products.Consumer
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

            var abc = await _dataService.GenerateQuotation(billmodel);
            var file = new SaveService();
            var mc = new MemoryStream(abc.Data);
            file.SaveAndView("test.pdf", "Application/pdf", mc);
        }

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

        [ObservableProperty]
        Customer custmorDetail;

        [ObservableProperty]
        GSTAmountModel amountModel;

        [ObservableProperty]
        ObservableCollection<SaleModel> saleItems;
        //AUTO mapper
    }
}

