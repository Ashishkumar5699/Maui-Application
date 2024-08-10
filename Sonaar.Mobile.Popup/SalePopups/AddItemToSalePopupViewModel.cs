using System.Collections.ObjectModel;
using System.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel;
using Sonaar.Mobile.Models.Common;
using Sonaar.Mobile.Models.Sale;

namespace Sonaar.Mobile.Popup.SalePopups
{
	public partial class AddItemToSalePopupViewModel : ObservableObject, INotifyPropertyChanged
	{
        #region Constructor
        public AddItemToSalePopupViewModel(SaleModel saleModel = null)
        {
            SaleItem = saleModel ?? new SaleModel();
            AddpickerItemSource();
        }

        #endregion

        #region Methods
        private void AddpickerItemSource()
        {
            HsnList = new ObservableCollection<CodeDiscreption>
            {
                new CodeDiscreption
                {
                    Code = "711319",
                    Discreption = "711319(Gold)",
                },
                new CodeDiscreption
                {
                    Code = "7113",
                    Discreption = "7113(Silver)",
                },
                new CodeDiscreption
                {
                    Code = "7102",
                    Discreption = "7102(Diamond)",
                }
            };
            //SelectedHSN = HsnList.FirstOrDefault();

            PurityList = new ObservableCollection<CodeDiscreption>
            {
                new CodeDiscreption
                {
                    Code = "18K",
                    Discreption = "18K (750)",
                },
                new CodeDiscreption
                {
                    Code = "22K",
                    Discreption = "22K (916)",
                },
            };
            //SelectedPurity = PurityList.FirstOrDefault();

            MakingList = new ObservableCollection<CodeDiscreption>
            {
                new CodeDiscreption
                {
                    Code = "800",
                    Discreption = "800",
                },
                new CodeDiscreption
                {
                    Code = "1000",
                    Discreption = "1000",
                },
                new CodeDiscreption 
                {
                    Code = "1250",
                    Discreption = "1250",
                }, new CodeDiscreption
                {
                    Code = "1450",
                    Discreption = "1450",
                },
                new CodeDiscreption
                {
                    Code = "1550",
                    Discreption = "1550",
                },
            };
            //SelectedMaking = MakingList.FirstOrDefault();
        }

        #endregion

        #region Bindable Properties
        [ObservableProperty]
        SaleModel saleItem;

        [ObservableProperty]
        ObservableCollection<CodeDiscreption> hsnList;

        [ObservableProperty]
        ObservableCollection<CodeDiscreption> purityList;

        [ObservableProperty]
        ObservableCollection<CodeDiscreption> makingList;

        private CodeDiscreption _selectedHSN;
        public CodeDiscreption SelectedHSN
        {
            get => _selectedHSN;
            set
            {
                SetProperty(ref _selectedHSN, value);
                SaleItem.HSN_Code = SelectedHSN.Code;
            }
        }

        private CodeDiscreption _selectedPurity;
        public CodeDiscreption SelectedPurity
        {
            get => _selectedPurity;
            set
            {
                SetProperty(ref _selectedPurity, value);
                SaleItem.Purity = SelectedPurity.Code;
            }
        }

        private CodeDiscreption _selectedMaking;
        public CodeDiscreption SelectedMaking
        {
            get => _selectedMaking;
            set
            {
                SetProperty(ref _selectedMaking, value);
                SaleItem.Making_Charge = decimal.Parse(SelectedMaking.Code);
            }
        }

        #endregion

    }
}