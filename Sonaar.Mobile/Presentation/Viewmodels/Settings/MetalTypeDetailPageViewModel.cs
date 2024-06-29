using Sonaar.Infrastructure.APIService;
using Sonaar.Infrastructure.Database;
using Sonaar.Infrastructure.Navigation;

namespace Sonaar.Presentation.Viewmodels.Settings
{
    public partial class MetalTypeDetailPageViewModel : BaseViewModel
    {
        public MetalTypeDetailPageViewModel(IDataService localDataService, INavigationService navigationservice) : base(localDataService, navigationservice)
        {
        }

        internal Task OnAppearing()
        {
            throw new NotImplementedException();
        }
    }
}
