using AutoMapper;
using Sonaar.Domain.Dto.ReportGeneration;
using Sonaar.Domain.Response;
using Sonaar.Mobile.Models.QuickSale;
using Sonaar.Mobile.RestBridge.RestService;
using Sonaar.Mobile.RestBridge.Urls;

namespace Sonaar.Services.BusinessLayer.Print
{
    public class PrintProvider : IPrintProvider
    {
        private readonly IRestService _restService;
        private readonly IMapper _mapper;

        public PrintProvider(IRestService restService, IMapper mapper)
        {
            _restService = restService;
            _mapper = mapper;
        }

        public async Task<ResponseResult<byte[]>> GenerateQuotation(PrintBillModel printBillModel)
        {
            printBillModel.FirmDetail = new Domain.Models.Company.FirmDetail
            {
                FirmName = "FirmName",
                FirmAddress = "FirmAddress",
                FirmGSTNumber = "FirmGSTNumber",
                FirmPhoneNumber = "FirmPhoneNumber",
            };

            var printBillDto = _mapper.Map<PrintBillDto>(printBillModel);

            var response = new ResponseResult<byte[]>
            {
                HasErrors = true,
                IsSystemError = true,
            };

            response = await _restService.PostAsync(ApiConstant.GenerateQuote, printBillDto, response);
            response.Message ??= "Opening Pdf";
            return response;
        }
    }
}

