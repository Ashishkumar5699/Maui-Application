using System;
using Sonaar.Mobile.Models.Sale;

namespace Sonaar.Mobile.Services.PopupService
{
	public interface ISalePopupService
	{
        Task<SaleModel> ShowClientMessage(SaleModel options);
    }
}

