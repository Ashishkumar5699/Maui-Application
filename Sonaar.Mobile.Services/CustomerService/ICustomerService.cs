using System;
using Sonaar.Domain.Response;
using Sonaar.Mobile.Models.Client;

namespace Sonaar.Mobile.Services.CustomerService
{
	public interface ICustomerService
	{
        Task<ExecResult> AddCustomer(Customer customer);

        Task<ResponseResult<Customer>> UpdateCustpmer(Customer customer);

        Task<ResponseResult<Customer>> DeleteCustomer(Customer customer);

        Task<List<Customer>> GetAllCustomers();

        Task<Customer> GetCustomerByPhone(long phone);
    }
}

