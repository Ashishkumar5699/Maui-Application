﻿using AutoMapper;
using Sonaar.Domain.Dto.ReportGeneration;
using Sonaar.Domain.Response;
using Sonaar.Mobile.Models.QuickSale;
using Sonaar.Mobile.RestBridge.RestService;
using Sonaar.Mobile.RestBridge.Urls;

namespace Sonaar.Services.BusinessLayer.Print
{
    public class PrintProvider(IRestService restService, IMapper mapper) : BaseBussinessLayer(mapper), IPrintProvider
    {
        private readonly IRestService _restService = restService;
        private readonly IMapper _mapper;

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

