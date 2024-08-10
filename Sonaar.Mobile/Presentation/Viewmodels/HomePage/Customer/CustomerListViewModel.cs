using Sonaar.Infrastructure.Database;
using Sonaar.Infrastructure.Navigation;
using System.Collections.ObjectModel;

namespace Sonaar.Presentation.Viewmodels.HomePage.Customer
{
    public partial class CustomerListViewModel : BaseViewModel
    {
        //#region private Menbers
        //private ObservableCollection<Domain.Customer.Customer> _custmorList;
        //#endregion

        //#region Constructor and initial methods
        public CustomerListViewModel(IDataService localDataService, INavigationService navigationservice) : base(localDataService, navigationservice)
        {
        }
        //public async Task OnAppearing()
        //{
        //    var listofCustomers = await _dataService.GetAllCustomers();
        //    CustomerList = new ObservableCollection<Domain.Customer.Customer>(listofCustomers);
        //}
        //#endregion

        //#region BindableProperties
        //public ObservableCollection<Domain.Customer.Customer> CustomerList
        //{
        //    get => _custmorList;
        //    set
        //    {
        //        _custmorList = value;
        //        OnPropertyChanged();
        //    }
        //}
        //#endregion
    }
}
