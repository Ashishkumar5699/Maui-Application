using System;
using CommunityToolkit.Maui.Core;
using Sonaar.Domain.Models.Response;
using Sonaar.Mobile.Models.Client;
using Sonaar.Mobile.Services.AlertService;
using Sonaar.Services.BusinessLayer.Consumer;
using Sonaar.Services.BusinessLayer.Print;

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
        public async Task<ResponseResult<Customer>> AddCustomer(Customer customer)
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

        public Task<List<Customer>> GetAllCustomers()
        {
            throw new NotImplementedException();
        }

        public Task<List<Customer>> GetCustomerByPhone(int phone)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseResult<Customer>> UpdateCustpmer(Customer customer)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}

