using Sonaar.Domain.Response;
using Sonaar.Mobile.Models.Client;

namespace Sonaar.Services.BusinessLayer.Consumer
{
    public interface IConsumerProvider
    {
        Task<ResponseResult<Customer>> AddCustomer(Customer printBillModel);
        Task<ResponseResult<List<Customer>>> GetAllCustomers();
    }
}