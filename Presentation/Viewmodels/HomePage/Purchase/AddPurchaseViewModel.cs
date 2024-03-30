using Punjab_Ornaments.Infrastructure.Database;
using Punjab_Ornaments.Infrastructure.Navigation;
using System.Windows.Input;

namespace Punjab_Ornaments.Presentation.Viewmodels.HomePage.Purchase
{
    public partial class AddPurchaseViewModel : BaseViewModel
    {
        #region Private Members
        private Models.Approvals.PurchaseRequest _purchaseItem;
        #endregion

        #region Commands
        public ICommand AddPurchaseCommnad => new Command(async () => await AddPurchaseAsync(PurchaseItem));
        #endregion

        #region constructor and initial methods

        public AddPurchaseViewModel(IDataService localDataService, INavigationService navigationservice) : base(localDataService, navigationservice)
        {
        }

        public void OnAppearing()
        {
            UpdateDefaultValues();
        }
        #endregion

        #region BindableProperties
        public Models.Approvals.PurchaseRequest PurchaseItem
        {
            get => _purchaseItem;
            set
            {
                _purchaseItem = value;
                OnPropertyChanged();
            }
        }
        #endregion
        #region Methods
        async Task AddPurchaseAsync(Models.Approvals.PurchaseRequest purchaseItem)
        {
            if (PurchaseItemValidation(purchaseItem))
            {
                //await _apiservice.AddGoldPurchaseRequst(purchaseItem);
                await _dataService.AddPurchase(purchaseItem);

                await _navigationService.PopAsync();
            }
            else
                await Application.Current.MainPage.DisplayAlert("Error", "please fill all fields", "Okay");
        }
        private void UpdateDefaultValues()
        {
            PurchaseItem = new Models.Approvals.PurchaseRequest
            {
                MatelType = null,
                ItemType = string.Empty,
                Brand = string.Empty,
                ManufactureId = string.Empty,
                ManufactureName = string.Empty,
                GrossWeight = 0,
                LessWeight = 0,
                NetWeight = 0,
                Quantity = 0,
                Rate = 0,
                Wastage = 0,
                Labour = 0,
                PurchaseDate = DateTime.Today,
            };
        }

        private static bool PurchaseItemValidation(Models.Approvals.PurchaseRequest purchaseItem)
        {
            if (purchaseItem.MatelType == string.Empty) return false;
            else if (purchaseItem.ItemType == string.Empty) return false;
            else if (purchaseItem.Brand == string.Empty) return false;
            else if (purchaseItem.ManufactureId == string.Empty) return false;
            else if (purchaseItem.ManufactureName == string.Empty) return false;
            else if (purchaseItem.GrossWeight == 0) return false;
            else if (purchaseItem.NetWeight <= 0) return false;
            else if (purchaseItem.Quantity == 0) return false;
            else if (purchaseItem.Rate == 0) return false;
            else if (purchaseItem.Wastage == 0) return false;
            else if (purchaseItem.NetWeight == 0) return false;
            else if (purchaseItem.NetWeight == 0) return false;

            return true;
        }

        internal void UpdateWeight()
        {
            PurchaseItem.NetWeight = PurchaseItem.GrossWeight - PurchaseItem.LessWeight;
            OnPropertyChanged(nameof(PurchaseItem));
        }
        #endregion
    }
}
