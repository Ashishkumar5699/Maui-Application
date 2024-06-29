using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Sonaar.Mobile.Services.Navigation;
using Sonaar.Mobile.UI.Common;

namespace Sonaar.Mobile.UI.Mortgage
{
    public partial class MortgageViewModel : BaseViewModel
    {
        #region Private Members

        private DateTime _datedifference;

        #endregion

        public MortgageViewModel(INavigationService navigationService) : base(navigationService)
        {
        }

        #region Commands

        [RelayCommand]
        private async Task CalculateAction()
        {
            try
            {
                switch (SelectedIntrestCalculationMode)
                {
                    case "Normal":
                        CalculateNormalMethod();
                        break;
                    default:
                        CalculateNormalMethod();
                        break;
                }

                IsCalculated = true;
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "Okay");
            }
            finally
            {
                OnPropertyChanged(nameof(IsNotCalculated));
            }
        }

        [RelayCommand]
        private void ResetAction()
        {
            StartDate = DateTime.Today.AddDays(-1);
            EndDate = DateTime.Today;
            MortagageAmount = 0;
            IntrestRate = 3;
            IsCalculated = false;
            OnPropertyChanged(nameof(IsNotCalculated));
        }

        #endregion

        #region Helper Functions

        private void CalculateNormalMethod()
        {
            var monthlIntrest = MortagageAmount * IntrestRate * DateDifference.Month / 100;
            var DayIntrest = MortagageAmount * IntrestRate * DateDifference.Day / 100;
            IntrestAmount = monthlIntrest + DayIntrest;
            TotalAmount = MortagageAmount + IntrestAmount;
            IsCalculated = false;
        }

        private DateTime CalculateDateDifference()
        {
            return SelectedDateCalculationMethod switch
            {
                "Day" => CalculateDaywise(),
                _ => CalculateMonthwise(),
            };
        }

        private DateTime CalculateDaywise()
        {
            var diff = EndDate - StartDate;
            return new DateTime(0,0,diff.Days);
        }

        private DateTime CalculateMonthwise()
        {
            var yearDiff = EndDate.Year - StartDate.Year;
            var monthDiff = EndDate.Month - StartDate.Month;
            var dayDiff = EndDate.Day - StartDate.Day;

            var total_months = yearDiff * 12 + monthDiff;

            return new DateTime(0, total_months, dayDiff);
        }

        #endregion

        #region Properties

        [ObservableProperty]
        public DateTime startDate = DateTime.Today.AddDays(-1);

        [ObservableProperty]
        public DateTime endDate = DateTime.Today;

        public DateTime DateDifference
        {
            get => _datedifference;
            set
            {
                if (_datedifference == value)
                    return;

                _datedifference = CalculateDateDifference();
                SetProperty(ref _datedifference, value);
                OnPropertyChanged(nameof(StartDate));
                OnPropertyChanged(nameof(EndDate));
            }
        }

        [ObservableProperty]
        public string selectedDateCalculationMethod;

        [ObservableProperty]
        public double mortagageAmount = 10000;

        [ObservableProperty]
        public double intrestRate = 3;

        [ObservableProperty]
        public double totalAmount;

        [ObservableProperty]
        public object selectedIntrestCalculationMode;

        [ObservableProperty]
        public bool isCalculated;

        [ObservableProperty]
        public double intrestAmount;

        public bool IsNotCalculated => !IsCalculated;

        #endregion
    }
}

