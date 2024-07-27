using System.Diagnostics;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui.Views;
using Microsoft.Extensions.Logging;
using Sonaar.Mobile.Popup.SalePopups;

namespace Sonaar.Mobile.Services.PopupService
{
    public abstract class PopupServiceBase
	{
		protected readonly ILogger<PopupServiceBase> Logger;
        protected readonly IPopupService _popupService;

        //protected ContentPage Page;

        public PopupServiceBase(ILogger<PopupServiceBase> logger, IPopupService popupService)
		{
			Logger = logger;
            _popupService = popupService;
        }

        //public virtual void Register(ContentPage page)
        //{
        //    Page = page;
        //}

        //protected async Task<(TViewModel, TModel)> ShowPopup<TViewModel, TModel>(TViewModel viewModel)
        //{
        //    try
        //    {
        //        //var popupResult = await PopupService.ShowPopupAsync<TViewModel>(viewModel);
        //        //var popupResult = await PopupService.ShowPopupAsync(popup);
        //        //var popupResult = await Page.ShowPopupAsync(popup);
        //        if (popupResult is TModel result)
        //    {
        //        return result;
        //            }
        //        }
        //    catch (Exception ex)
        //    {
        //        var type = popup.GetType();
        //        Logger.LogError(ex, $"Error encountered showing popup {type.Namespace}.{type.Name}");
        //        throw;
        //    }
        //}
        //{
        //if (Page == null)
        //{
        //    Debug.WriteLine("ERROR: No registered page found for ShowPoup()."); ;
        //    return default;
        //}

            //    try
            //    {
            //        var popupResult = await PopupService.ShowPopupAsync<TViewModel>();
            //        //var popupResult = await PopupService.ShowPopupAsync(popup);
            //        //var popupResult = await Page.ShowPopupAsync(popup);
            //        if (popupResult is TModel result)
            //        {
            //            return result;
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        var type = popup.GetType();
            //        Logger.LogError(ex, $"Error encountered showing popup {type.Namespace}.{type.Name}");
            //        throw;
            //    }
            //    return default;
            //}

            //protected async Task<TResult> ShowPopup<TResult>(Page popup)
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

