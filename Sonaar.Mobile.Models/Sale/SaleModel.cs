using System;
using System.ComponentModel;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Sonaar.Mobile.Models.Sale
{
	public partial class SaleModel : ObservableObject, INotifyPropertyChanged
    {
        public int Id { get; set; }

        [ObservableProperty]
        public string description;

        [ObservableProperty]
        public string hSN_Code;

        [ObservableProperty]
        public string purity;

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

        public decimal _rate;
        public decimal Rate
        {
            get => _rate;
            set
            {
                SetProperty(ref _rate, value);
                OnPropertyChanged(nameof(Amount));
            }
        }

        public decimal _making_Charge;
        public decimal Making_Charge
        {
            get => _making_Charge;
            set
            {
                SetProperty(ref _making_Charge, value);
                OnPropertyChanged(nameof(Amount));
            }
        }

        public decimal Amount => Sonaar.Domain.Helper.Utilities.GetAmount(Rate,Making_Charge,Weight);

        public event EventHandler ChildUpdated;

        // Method to update child entity
        public void UpdateChildName(string newName)
        {
            //ChildName = newName;
            ChildUpdated?.Invoke(this, EventArgs.Empty);
        }
    }
}

