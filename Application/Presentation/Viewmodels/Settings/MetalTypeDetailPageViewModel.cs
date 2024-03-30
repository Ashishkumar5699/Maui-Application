using Punjab_Ornaments.Infrastructure.APIService;
using Punjab_Ornaments.Infrastructure.Database;
using Punjab_Ornaments.Infrastructure.Navigation;

namespace Punjab_Ornaments.Presentation.Viewmodels.Settings
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
