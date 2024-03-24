using Punjab_Ornaments.Infrastructure.Database;
using Punjab_Ornaments.Infrastructure.Navigation;
using Punjab_Ornaments.Resources.Constant;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Punjab_Ornaments.Presentation.Viewmodels.Approval
{
    public partial class ApprovalViewModel : BaseViewModel
    {
        #region Private Members
        private ObservableCollection<Models.Approvals.PurchaseRequest> _puchaseList;

        #endregion

        #region Commands
        public ICommand NavigateToPurchaseDetailPageCommnad => new Command<int>(async (purchaseid) => await NavigateToPurchaseDetailPageAsync(purchaseid));
        #endregion


        public ApprovalViewModel(IDataService localDataService, INavigationService navigationservice) : base(localDataService, navigationservice)
        {
        }
        #region Bindable Properties
        public ObservableCollection<Models.Approvals.PurchaseRequest> PuchaseList
        {
            get => _puchaseList;
            set
            {
                _puchaseList = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region Methods
        public async Task<List<Models.Approvals.PurchaseRequest>> GetAllPendingPurchaseRequests() => await _dataService.GetAllPendingPurchases();

        private async Task NavigateToPurchaseDetailPageAsync(int purchaseid) => await _navigationService.NavigateToAsync(NavigationPath.PurchaseDetailPage, "PurchaseId", purchaseid);
        #endregion
    }
}
