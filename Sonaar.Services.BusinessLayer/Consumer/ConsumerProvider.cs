using AutoMapper;
using Sonaar.Domain.Dto.CustomerDirectory;
using Sonaar.Domain.Entities.Contacts;
using Sonaar.Domain.Response;
using Sonaar.Mobile.Models.Client;
using Sonaar.Mobile.RestBridge.RestService;
using Sonaar.Mobile.RestBridge.Urls;

namespace Sonaar.Services.BusinessLayer.Consumer
{
    public class ConsumerProvider : BaseBussinessLayer, IConsumerProvider
    {
        private readonly IRestService _restService;

        public ConsumerProvider(IRestService restService, IMapper mapper) : base(mapper)
        {
            _restService = restService;
        }

        public async Task<ExecResult> AddCustomer(Customer customer)
        {
            var response = new ExecResult();

            try
            {
                var CustmorDTO = _mapper.Map<ConsumerDTO>(customer);
                response = await _restService.PostAsync(ApiConstant.AddContacts, CustmorDTO, response);
            }
            catch (Exception ex)
            {
                response.IsSystemError = true;
                response.Message = ex.ToString();
            }

            return response;
        }

        public async Task<ResponseResult<IEnumerable<Customer>>> GetAllCustomers()
        {
            var response = new ResponseResult<IEnumerable<Customer>>();

            try
            {
                var bussinessResponse =  await _restService.GetAsync<ResponseResult<List<ContactDetails>>>(ApiConstant.GetAllContacts, null);
                response.Data = _mapper.Map<IEnumerable<Customer>>(bussinessResponse.Data);
                response.Message = bussinessResponse.Message;
            }
            catch (Exception ex)
            {
                response.IsSystemError = true;
                response.Message = ex.ToString();
            }

            return response;
        }
    }
}

