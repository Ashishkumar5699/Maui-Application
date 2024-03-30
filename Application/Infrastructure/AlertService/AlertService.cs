using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using System.Threading;

namespace Punjab_Ornaments.Infrastructure.AlertService
{
    public class AlertService : IAlertService
    {
        private readonly CancellationTokenSource cancellationTokenSource;

        public AlertService()
        {
            cancellationTokenSource = new CancellationTokenSource();
        }

        public async Task ShowAlert(string text, ToastDuration duration, int fontSize)
        {
            var toast = Toast.Make(text, duration, fontSize);

            await toast.Show(cancellationTokenSource.Token);
        }
    }
}
