using Sonaar.Infrastructure.Database;
using Sonaar.Infrastructure.Navigation;
using System.Collections.ObjectModel;

namespace Sonaar.Presentation.Viewmodels.Approval
{
    public partial class PendingApprovalsViewModel : ApprovalViewModel
    {
        #region Private Members
        public PendingApprovalsViewModel(IDataService localDataService, INavigationService navigationservice) : base(localDataService, navigationservice)
        {
        }

        internal async Task OnAppearing()
        {
            var _purchaselist = await GetAllPendingPurchaseRequests();
            PuchaseList = new ObservableCollection<Domain.Approvals.PurchaseRequest>(_purchaselist.Where(x => x.IsApproved == null));
        }
        #endregion
    }
}
