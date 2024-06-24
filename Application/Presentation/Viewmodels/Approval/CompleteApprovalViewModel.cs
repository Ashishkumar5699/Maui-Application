using Sonaar.Infrastructure.APIService;
using Sonaar.Infrastructure.Database;
using Sonaar.Infrastructure.Navigation;
using System.Collections.ObjectModel;

namespace Sonaar.Presentation.Viewmodels.Approval
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
            PuchaseList = new ObservableCollection<Domain.Approvals.PurchaseRequest>(_purchaselist.Where(x => x.IsApproved != null));
        }
        #endregion
    }
}
