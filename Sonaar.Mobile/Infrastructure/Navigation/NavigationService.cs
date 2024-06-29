
using Sonaar.Presentation.Viewmodels;
using Sonaar.Presentation.Viewmodels.Common;
using Sonaar.Resources.Constant;

namespace Sonaar.Infrastructure.Navigation
{
    public partial class NavigationService : INavigationService
    {
        public async Task NavigateToAsync(NavigationPath route, string routeParameters = null, object routeobj = null)
        {
            try
            {
                if( routeParameters == null || routeobj == null )
                {
                    await Shell.Current.GoToAsync($"/{route}");
                }
                else
                {
                    await Shell.Current.GoToAsync($"/{route}", new Dictionary<string, object> { { routeParameters, routeobj } });
                }
                //var data = Application.Current.MainPage.BindingContext; 
                //await (data as  BaseViewModel).InitializeAsync(routeobj);

            }
            catch(Exception ex)
            {

            }
        }

        public async Task PopAsync() => await Shell.Current.GoToAsync("..");
    }
}
