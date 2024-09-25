using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Sonaar.Mobile.Services.CustomerService;
using Sonaar.Mobile.Services.Navigation;
using Sonaar.Mobile.UI.Common;

namespace Sonaar.Mobile.UI.Customer
{
    public partial class AddNewCustomerPageViewModel : BaseViewModel
    {
        #region Private Members

        private readonly ICustomerService _customerService;

        #endregion

        public AddNewCustomerPageViewModel(ICustomerService customerService, INavigationService navigationService) : base(navigationService)
        {
            Customer = new Models.Client.Customer();
            _customerService = customerService;
        }

        #region Methods
        [RelayCommand]
        private async Task AddCustomer()
        {
            await _customerService.AddCustomer(Customer);
            await _navigationService.PopAsync();
        }
        #endregion

        #region BindableProperties

        [ObservableProperty]
        public Sonaar.Mobile.Models.Client.Customer customer;

        #endregion
    }
}

