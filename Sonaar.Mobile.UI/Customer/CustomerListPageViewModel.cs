using System;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Sonaar.Mobile.Services.CustomerService;
using Sonaar.Mobile.Services.Navigation;
using Sonaar.Mobile.UI.Common;

namespace Sonaar.Mobile.UI.Customer
{
	public partial class CustomerListPageViewModel : BaseViewModel
    {
        #region private Menbers
        private readonly ICustomerService _customerService;
        private ObservableCollection<Models.Client.Customer> _unfilteredContactsGroups;
        
        #endregion

        #region Constructor and initial methods
        public CustomerListPageViewModel(ICustomerService customerService, INavigationService navigationService) : base(navigationService)
        {
            _customerService = customerService;
        }

        public override async Task InitializeAsync(object obj = null)
        {
            var listofCustomers = await _customerService.GetAllCustomers();
            CustomerList = _unfilteredContactsGroups = new ObservableCollection<Models.Client.Customer>(listofCustomers);
        }

        #endregion

        #region Command

        [RelayCommand]
        public void Search()
        {
            if (string.IsNullOrWhiteSpace(SearchText))
            {
                // If the search text is empty, show all contacts
                CustomerList = _unfilteredContactsGroups;
            }
            else
            {
                // If the search text is not empty, show only contacts that contain the search text
                var filteredList = _unfilteredContactsGroups.Where(x =>
                                x.ContactFirstName.Contains(SearchText, StringComparison.InvariantCultureIgnoreCase)
                                || x.ContactFirstName.Contains(SearchText, StringComparison.InvariantCultureIgnoreCase)
                                || x.ContactPhoneNumber.Contains(SearchText, StringComparison.InvariantCultureIgnoreCase)
                                ).ToList();

                CustomerList = new ObservableCollection<Models.Client.Customer>(filteredList);

                //CustomerList = _unfilteredContactsGroups
                //    .Where(g => g.Any(c =>
                //        c.FirstName.Contains(SearchText, StringComparison.InvariantCultureIgnoreCase)
                //        || c.LastName.Contains(SearchText, StringComparison.InvariantCultureIgnoreCase)))
                //    .ToList();
            }
        }

        [RelayCommand]
        public async Task AddNewContact()
        {
            try
            {
                await _navigationService.NavigateToAsync(NavigationPath.AddNewCustomerPage);
            }
            catch (Exception ex)
            {

            }
        }

        #endregion

        #region BindableProperties

        [ObservableProperty]
        ObservableCollection<Models.Client.Customer> customerList;

        [ObservableProperty]
        string searchText;
        #endregion
    }
}

