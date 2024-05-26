using CommunityToolkit.Maui.Core;

namespace Punjab_Ornaments.Infrastructure.AlertService
{
    public interface IAlertService
    {
        Task ShowAlert(string text, ToastDuration duration, int fontSize);
    }
}
