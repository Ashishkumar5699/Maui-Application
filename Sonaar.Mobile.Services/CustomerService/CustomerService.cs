using CommunityToolkit.Maui.Core;
using Sonaar.Domain.Response;
using Sonaar.Mobile.Models.Client;
using Sonaar.Mobile.Services.AlertService;
using Sonaar.Services.BusinessLayer.Consumer;

namespace Sonaar.Mobile.Services.CustomerService
{
    public class CustomerService : ICustomerService
    {
        #region Private Members
        private readonly IConsumerProvider _restService;
        private readonly IAlertService _alertService;
        #endregion

        public CustomerService(IConsumerProvider restService, IAlertService alertService)
		{
            _restService = restService;
            _alertService = alertService;
        }

        #region Methods
        public async Task<ExecResult> AddCustomer(Customer customer)
        {
            var result = await _restService.AddCustomer(customer);

            ToastDuration duration = result.HasErrors || result.IsSystemError ? ToastDuration.Long : ToastDuration.Short;
            await _alertService.ShowAlert(result.Message, duration, 14);
            return result;
        }

        public Task<ResponseResult<Customer>> DeleteCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Customer>> GetAllCustomers()
        {
            var result = await _restService.GetAllCustomers();

            ToastDuration duration = result.HasErrors || result.IsSystemError ? ToastDuration.Long : ToastDuration.Short;
            await _alertService.ShowAlert(result.Message, duration, 14);
            return result.Data?.ToList() ?? new List<Customer>();
        }

        public async Task<Customer> GetCustomerByPhone(long phone)
        {
            var custmorList = (await _restService.GetAllCustomers())?.Data?.ToList();
            if(custmorList != null)
            {
                var customer = custmorList.Where(x => x.ContactPhoneNumber == phone.ToString()).FirstOrDefault();
                if(customer != null) return customer;
            }
            
            await _alertService.ShowAlert("No cusumer Found", ToastDuration.Long, 14);

            return null;
        }

        public Task<ResponseResult<Customer>> UpdateCustpmer(Customer customer)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}

