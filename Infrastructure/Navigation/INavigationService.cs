using Punjab_Ornaments.Resources.Constant;

namespace Punjab_Ornaments.Infrastructure.Navigation
{
    public interface INavigationService
    {
        //Task NavigateToAsync(string route, IDictionary<string, object> routeParameters = null);
        Task NavigateToAsync(NavigationPath route, string routeParameters = null, object routeobj = null);


        Task PopAsync();
    }
}
