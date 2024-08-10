using System;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using Sonaar.Mobile.Services.CustomerService;
using Sonaar.Mobile.Services.Navigation;
using Sonaar.Mobile.UI.Common;

namespace Sonaar.Mobile.UI.Customer
{
	public partial class CustomerListPageViewModel : BaseViewModel
    {
        #region private Menbers
        private readonly ICustomerService _customerService;
        #endregion

        #region Constructor and initial methods
        public CustomerListPageViewModel(ICustomerService customerService, INavigationService navigationService) : base(navigationService)
        {
            _customerService = customerService;
        }

        public override async Task InitializeAsync(object obj = null)
        {
            await Task.Delay(100);
            var listofCustomers = await _customerService.GetAllCustomers();
            CustomerList = new ObservableCollection<Models.Client.Customer>(listofCustomers);
        }

        #endregion

        #region BindableProperties

        [ObservableProperty]
        ObservableCollection<Models.Client.Customer> customerList;
        
        #endregion
    }
}

