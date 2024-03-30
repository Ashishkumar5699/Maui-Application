using Punjab_Ornaments.Infrastructure.APIService;
using Punjab_Ornaments.Infrastructure.Database;
using Punjab_Ornaments.Infrastructure.Navigation;
using System.Collections.ObjectModel;

namespace Punjab_Ornaments.Presentation.Viewmodels.Approval
{
    public partial class CompleteApprovalViewModel : ApprovalViewModel
    {

        #region construction and init methods
        public CompleteApprovalViewModel(IDataService localDataService, INavigationService navigationservice) : base(localDataService, navigationservice)
        {
        }
        internal async Task OnAppearing()
        {
            //var _pendingpurchaselist = await _dataService.GetAllCompletePurchases();
            var _purchaselist = await GetAllPendingPurchaseRequests();
            PuchaseList = new ObservableCollection<Models.Approvals.PurchaseRequest>(_purchaselist.Where(x => x.IsApproved != null));
        }
        #endregion
    }
}
