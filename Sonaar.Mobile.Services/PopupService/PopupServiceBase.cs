using System.Diagnostics;
using Microsoft.Extensions.Logging;

namespace Sonaar.Mobile.Services.PopupService
{
    public abstract class PopupServiceBase
	{
		protected readonly ILogger<PopupServiceBase> Logger;

        protected ContentPage Page;

        public PopupServiceBase(ILogger<PopupServiceBase> logger)
		{
			Logger = logger;
        }

        public virtual void Register(ContentPage page)
        {
            Page = page;
        }

        //protected async Task<TResult> ShowPopup<TResult>(Popup popup)
        //{
        //    if (Page == null)
        //    {
        //        Debug.WriteLine("ERROR: No registered page found for ShowPoup()."); ;
        //        return default;
        //    }

        //    try
        //    {
        //        var popupResult = await Page.ShowPopupAsync(popup);
        //        if (popupResult is TResult result)
        //        {
        //            return result;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        var type = popup.GetType();
        //        Logger.LogError(exception: ex, message: $"Error encountered showing popup {type.Namespace}.{type.Name}", popup);
        //        throw;
        //    }
        //    return default;
        //}
    }
}

