using System;
using Sonaar.Domain.Models.Response;
using Sonaar.Mobile.Models.Client;

namespace Sonaar.Services.BusinessLayer.Consumer
{
	public class ConsumerProvider : IConsumerProvider
    {
		public ConsumerProvider()
		{
		}

        public Task<ResponseResult<Customer>> AddCustomer(Customer printBillModel)
        {
            throw new NotImplementedException();
        }
    }
}

