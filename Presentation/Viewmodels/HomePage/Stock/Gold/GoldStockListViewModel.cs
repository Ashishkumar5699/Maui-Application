using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Punjab_Ornaments.Infrastructure.Database;
using Punjab_Ornaments.Infrastructure.Navigation;
using Punjab_Ornaments.Models;
using Punjab_Ornaments.Resources.Constant;
using System.Collections.ObjectModel;

namespace Punjab_Ornaments.Presentation.Viewmodels
{
    public partial class GoldStockListViewModel : BaseViewModel
    {
        #region private Members
        private ObservableCollection<Gold> _goldStockList;
        #endregion

        #region Constructor and override methods
        public GoldStockListViewModel(IDataService localDataService, INavigationService navigationservice) : base(localDataService, navigationservice)
        {
        }

        public async Task OnAppearing()
        {
            var listofStock = await _dataService.GetAllGoldStock();
            GoldStockList = new ObservableCollection<Gold>(listofStock);
        }

        #endregion

        #region Bindable Properties
        public ObservableCollection<Gold> GoldStockList
        {
            get => _goldStockList;
            set
            {
                _goldStockList = value;
                OnPropertyChanged();
            }
        }

        #region propertygeneratebypackage
        [ObservableProperty]
        string code;

        [ObservableProperty]
        decimal weight;

        [ObservableProperty]
        string image;

        [ObservableProperty]
        Models.Products.Details.Discriptions brand;

        [ObservableProperty]
        string carrot;

        #endregion

        #endregion

        #region Command
        [RelayCommand]
        public static async Task NavigateToAddnewPage() => await Shell.Current.GoToAsync("/AddGoldStock");

        [RelayCommand]
        public void AddNewItem()
        {
            Gold gold = new() { Code = Code, Weight = Weight, Image = Image, Brand = "Dhanya" , Carrot = Carrot};
            _dataService.AddGoldinStock(gold);
            _navigationService.PopAsync();
        }

        [RelayCommand]
        public static void DeleteItem(Gold gold)
        {
            //Gold gold = new() { Code = Code, Weight = Weight, Image = Image, Brand = Brand, Carrot = Carrat };
            //_dataService.AddGoldinStock(gold);
            //navigationservice.PopAsync();
        }

        [RelayCommand]
        public async Task NavigatetoDetailPage(int id)
        {
            await _navigationService.NavigateToAsync(NavigationPath.GoldStockDetailPage, "id", id);
        }
        #endregion
    }
}
