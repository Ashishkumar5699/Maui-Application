using System.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Sonaar.Mobile.Models.Sale
{
    public partial class SaleModel : ObservableObject
    {
        public int Id { get; set; }

        [ObservableProperty]
        string description;

        [ObservableProperty]
        string hSN_Code;

        [ObservableProperty]
        string purity;

        private decimal _weight;
        public decimal Weight
        {
            get => _weight;
            set
            {
                SetProperty(ref _weight, value);
                OnPropertyChanged(nameof(Amount));
            }
        }

        private decimal _rate;
        public decimal Rate
        {
            get => _rate;
            set
            {
                SetProperty(ref _rate, value);
                OnPropertyChanged(nameof(Amount));
            }
        }

        private decimal _making_Charge;
        public decimal Making_Charge
        {
            get => _making_Charge;
            set
            {
                SetProperty(ref _making_Charge, value);
                OnPropertyChanged(nameof(Amount));
            }
        }

        public decimal Amount => Sonaar.Domain.Helper.Utilities.GetAmount(Rate, Making_Charge, Weight);

        public bool IsExisting { get; set; }
    }
}

