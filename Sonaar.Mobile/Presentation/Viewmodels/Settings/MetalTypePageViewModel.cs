using Sonaar.Infrastructure.APIService;
using Sonaar.Infrastructure.Database;
using Sonaar.Infrastructure.Navigation;
using Sonaar.Domain.Products.Details;
using Sonaar.Resources.Constant;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Sonaar.Presentation.Viewmodels.Settings
{
    [QueryProperty(nameof(Id), "Id")]
    public partial class MetalTypePageViewModel : BaseViewModel
    {
        #region Private Members
        private ObservableCollection<Discriptions> _metalTypeList;
        private int _id;

        public MetalTypePageViewModel(IDataService localDataService, INavigationService navigationservice) : base(localDataService, navigationservice)
        {
        }
        #endregion

        #region Commands
        public ICommand NavigateAddMetaltypePageCommnad => new Command(async () => await NavigateAddMetaltypePageAsync());
        public ICommand NavigateToMetalDetailPageCommnad => new Command<int>(async (i) => await NavigateToMetalDetailPageAsync(i));
        #endregion
        #region Constructor and init Method
        public async Task OnAppearing()
        {
            var metelTypes = await _dataService.GetAllMetalType();
            MetalTypeList = new ObservableCollection<Discriptions>(metelTypes);
        }
        #endregion

        #region Properties
        public ObservableCollection<Discriptions> MetalTypeList
        {
            get => _metalTypeList;
            set
            {
                _metalTypeList = value;
                OnPropertyChanged();
            }
        }
        public int Id
        {
            get => _id;
            set
            {
                _id = value;
                OnPropertyChanged();
            }
        }
        #endregion
        #region Methods
        public async Task NavigateAddMetaltypePageAsync()
        {
            await _navigationService.NavigateToAsync(NavigationPath.MetalTypeDetailPage);
        }
        public async Task NavigateToMetalDetailPageAsync(int id)
        {
            await _navigationService.NavigateToAsync(NavigationPath.MetalTypeDetailPage, "Id", id);
        }
        #endregion
    }
}
