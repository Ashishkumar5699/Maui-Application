using Punjab_Ornaments.Infrastructure.Database;
using Punjab_Ornaments.Infrastructure.Navigation;
using System.Windows.Input;

namespace Punjab_Ornaments.Presentation.Viewmodels.Approval
{
    [QueryProperty(nameof(PurchaseRequestId), "PurchaseId")]
    public partial class PurchaseDetailViewModel : BaseViewModel
    {
        #region Private Members
        public int _purchaserequestId;
        private Models.Approvals.PurchaseRequest _purchaseitem;
        private bool _approverejectbtnvisible;
        private bool _deletebtnvisible;
        private bool _addtostockbtnvisible;
        #endregion

        #region Commands
        public ICommand ApprovedCommnad => new Command<bool>(async (isapproved) => await ApprovedAsync(isapproved));
        public ICommand DeleteCommnad => new Command<int>( (purchaseid) => DeleteAsync(purchaseid));

        public ICommand AddToStockCommnad => new Command<int>(async (purchaseid) => await AddToStockAsync(purchaseid));

        #endregion

        #region Constructor and init methods
        public PurchaseDetailViewModel(IDataService localDataService, INavigationService navigationservice) : base(localDataService, navigationservice)
        {
        }
        internal async Task OnAppearing()
        {
            var purchaseitem = await _dataService.GetPurchaseById(PurchaseRequestId);
            Purchaseitem = purchaseitem.FirstOrDefault();
            Init();
        }
        #endregion

        #region Bindable Properties
        public int PurchaseRequestId
        {
            get => _purchaserequestId;
            set
            {
                _purchaserequestId = value;
                OnPropertyChanged(nameof(PurchaseRequestId));
            }
        }
        public Models.Approvals.PurchaseRequest Purchaseitem
        {
            get => _purchaseitem;
            set
            {
                _purchaseitem = value;
                OnPropertyChanged(nameof(Purchaseitem));
            }
        }
        public bool ApproveRejectbtnvisible
        {
            get => _approverejectbtnvisible;
            set
            {
                _approverejectbtnvisible = value;
                OnPropertyChanged(nameof(ApproveRejectbtnvisible));
            }
        }
        public bool Deletebtnvisible
        {
            get => _deletebtnvisible;
            set
            {
                _deletebtnvisible = value;
                OnPropertyChanged(nameof(Deletebtnvisible));
            }
        }
        public bool AddtoStockbtnvisible
        {
            get => _addtostockbtnvisible;
            set
            {
                _addtostockbtnvisible = value;
                OnPropertyChanged(nameof(AddtoStockbtnvisible));
            }
        }
        #endregion

        #region Methods
        private void Init()
        {
            ShowButtons();
        }
        private void ShowButtons()
        {
            if (Purchaseitem == null)
                return;

            ApproveRejectbtnvisible = Purchaseitem.IsApproved == null;

            if (ApproveRejectbtnvisible)
                return;
            
            Deletebtnvisible = Purchaseitem.IsApproved == 0;
            AddtoStockbtnvisible = !Deletebtnvisible;
        }
        private async Task ApprovedAsync(bool isapproved)
        {
            var issucess = await _dataService.ApprovedPurchase(PurchaseRequestId, isapproved ? 1 : 0);
            await OnAppearing();
        }

        private Task DeleteAsync(int purchaseid)
        {
            throw new NotImplementedException();
        }
        private Task AddToStockAsync(int purchaseid)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
