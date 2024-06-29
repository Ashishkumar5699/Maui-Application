using CommunityToolkit.Mvvm.Input;
using Sonaar.Infrastructure.APIService;
using Sonaar.Infrastructure.Database;
using Sonaar.Infrastructure.Navigation;

namespace Sonaar.Presentation.Viewmodels
{
    public partial class StockViewModel : BaseViewModel
    {
        public StockViewModel(IDataService localDataService, INavigationService navigationservice) : base(localDataService, navigationservice)
        {
        }

        [RelayCommand]
        public static async Task AddNewGold() => await Shell.Current.GoToAsync("/GoldStockList");
    }
}
