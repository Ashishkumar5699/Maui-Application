using CommunityToolkit.Maui.Core;
using Microsoft.Extensions.Logging;
using Sonaar.Mobile.Models.Sale;
using Sonaar.Mobile.Popup.SalePopups;

namespace Sonaar.Mobile.Services.PopupService
{
    public class SalePopupService : PopupServiceBase, ISalePopupService
    {
        public SalePopupService(ILogger<PopupServiceBase> logger, IPopupService popupService) : base(logger, popupService)
        {
        }

        public async Task<SaleModel> ShowClientMessage(SaleModel saleModel)
        {
            var vm = new AddItemToSalePopupViewModel(saleModel);
            var result = await _popupService.ShowPopupAsync(vm);

            if (result is SaleModel _saleItem)
                return _saleItem;

            return null;
        }
    }
}

