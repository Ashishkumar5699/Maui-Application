using CommunityToolkit.Maui.Core;

namespace Sonaar.Infrastructure.AlertService
{
    public interface IAlertService
    {
        Task ShowAlert(string text, ToastDuration duration, int fontSize);
    }
}
