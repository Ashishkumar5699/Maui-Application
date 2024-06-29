using System;
using Sonaar.Common.Models.Response;
using Sonaar.Mobile.Models.Prints;
using Sonaar.Mobile.RestBridge.RestService;
using Sonaar.Mobile.RestBridge.Urls;

namespace Sonaar.Services.BusinessLayer.Print
{
	public class PrintProvider: IPrintProvider
    {
        private readonly IRestService _restService;

        public PrintProvider(IRestService restService)
        {
            _restService = restService;
        }

        public async Task<ResponseResult<byte[]>> GenerateQuotation(PrintBillModel printBillModel)
        {
            //var data = new MemoryStream().ToArray();
            var response = new ResponseResult<byte[]>
            {
                HasErrors = true,
                IsSystemError = true,
            };

            response = await _restService.PostAsync(ApiConstant.GenerateQuote, printBillModel, response);
            response.Message ??= "Opening Pdf";
            return response;
        }
    }
}

