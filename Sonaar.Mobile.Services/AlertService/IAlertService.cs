using System;
using CommunityToolkit.Maui.Core;

namespace Sonaar.Mobile.Services.AlertService
{
	public interface IAlertService
	{
        Task ShowAlert(string text, ToastDuration duration, int fontSize);
    }
}

