using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using Punjab_Ornaments.Infrastructure.Database;
using Punjab_Ornaments.Infrastructure.Navigation;
using Punjab_Ornaments.Domain;
using Punjab_Ornaments.Domain.Sale;
using Punjab_Ornaments.Domain.Customer;

namespace Punjab_Ornaments.Presentation.Viewmodels.QuickSale
{
    public partial class SalePageViewModel : BaseViewModel
    {

        private ObservableCollection<SaleModel> _saleItems;
        private GSTAmountModel _amountModel;

        public SalePageViewModel(IDataService localDataService, INavigationService navigationService) : base(localDataService, navigationService)
        {
            AmountModel = new GSTAmountModel();
            SaleItems = new ObservableCollection<SaleModel>();

            UpdateCommand = new Command<int>(UpdateAction);
            GenerateBillCommand = new Command(GenerateBillAsync);

            Init();
        }

        public ICommand UpdateCommand { get; }
        public ICommand GenerateBillCommand { get; }

        private void Init()
        {
            for (int i = 1; i <= 5; i++)
            {
                SaleItems.Add(new SaleModel
                {
                    Id = i,
                    AmountUpdateCommand = UpdateCommand
                });
            }
        }

        private void GenerateBillAsync(object obj)
        {
            throw new NotImplementedException();
        }

        private void UpdateAction(int id)
        {
            decimal amount = 0;
            foreach (var item in SaleItems)
            {
                if (item.Id == id)
                    item.Amount = (item.Rate + item.Making_Charge) * item.Weight;

                amount += item.Amount;
            }
            AmountModel.Total = amount;
            OnPropertyChanged(nameof(SaleItems));
            OnPropertyChanged(nameof(AmountModel));

        }

        [ObservableProperty]
        Customer custmorDetail;

        [ObservableProperty]
        GSTAmountModel amountModel;

        [ObservableProperty]
        ObservableCollection<SaleModel> saleItems;
        //AUTO mapper
    }
}

