using System;
using Sonaar.Domain.Models.Response;
using Sonaar.Mobile.Models.Client;

namespace Sonaar.Mobile.Services.CustomerService
{
	public interface ICustomerService
	{
        Task<ResponseResult<Customer>> AddCustomer(Customer customer);

        Task<ResponseResult<Customer>> UpdateCustpmer(Customer customer);

        Task<ResponseResult<Customer>> DeleteCustomer(Customer customer);

        Task<List<Customer>> GetAllCustomers();

        Task<List<Customer>> GetCustomerByPhone(int phone);
    }
}

