using System;
using Microsoft.Extensions.Logging;
using Sonaar.Mobile.Models.Sale;
using Sonaar.Mobile.Popup.SalePopups;

namespace Sonaar.Mobile.Services.PopupService
{
    public class SalePopupService : PopupServiceBase, ISalePopupService
    {
        public SalePopupService(ILogger<PopupServiceBase> logger) : base(logger)
        {
        }

        public async Task<SaleModel> ShowClientMessage(SaleModel options)
        {
            var popup = new AddItemToSalePopup();
            return new SaleModel();
            //return await ShowPopup<SaleModel>(popup);
        }

        //public Task<bool> ShowClientMessage((string, string) options)
        //{
        //    var popup = new ClientMessagePopup
        //    {
        //        Text = options.Item1
        //    };

        //    if (!string.IsNullOrEmpty(options.Icon))
        //    {
        //        popup.Icon = options.Item2;
        //    }

        //    BindConfirmationCommands(popup);

        //    if (options.MillisecondsDelay > 0)
        //    {
        //        await Task.Delay(options.MillisecondsDelay);
        //    }

        //    return await ShowPopup<bool>(popup);
        //}


    }
}

