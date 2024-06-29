using System;
using CommunityToolkit.Maui.Core;
using Sonaar.Common.Models.Response;
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
            var result = await _restService.GenerateQuotation(printBillModel);

            ToastDuration duration = result.HasErrors || result.IsSystemError ? ToastDuration.Long : ToastDuration.Short;
            await _alertService.ShowAlert(result.Message, duration, 14);
            return result;
        }
    }
}

