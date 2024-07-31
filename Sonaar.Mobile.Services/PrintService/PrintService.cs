using System;
using CommunityToolkit.Maui.Core;
using Sonaar.Domain.Models.Response;
using Sonaar.Mobile.Models.Prints;
using Sonaar.Mobile.Services.AlertService;
using Sonaar.Services.BusinessLayer.Auth;
using Sonaar.Services.BusinessLayer.Print;

namespace Sonaar.Mobile.Services.PrintService
{
    public class PrintService : IPrintService
    {
        private readonly IPrintProvider _restService;
        private readonly IAlertService _alertService;

        public PrintService(IPrintProvider restService, IAlertService alertService)
        {
            _restService = restService;
            _alertService = alertService;
        }
        public async Task<ResponseResult<byte[]>> GenerateQuotation(PrintBillModel printBillModel)
        {
            printBillModel.FirmDetail = new Models.Company.FirmDetail
            {
                FirmName = "FirmName",
                FirmAddress = "FirmAddress",
                FirmGSTNumber = "FirmGSTNumber",
                FirmPhoneNumber = "FirmPhoneNumber",
            };

            printBillModel.DateofBill = DateTime.Today;
            printBillModel.BillType = Domain.Models.Bills.BillTypeEnum.Quotation;

            var result = await _restService.GenerateQuotation(printBillModel);

            ToastDuration duration = result.HasErrors || result.IsSystemError ? ToastDuration.Long : ToastDuration.Short;
            await _alertService.ShowAlert(result.Message, duration, 14);
            return result;
        }
    }
}

