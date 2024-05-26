using Punjab_Ornaments.Infrastructure.Database;
using Punjab_Ornaments.Infrastructure.Navigation;
using System.Windows.Input;

namespace Punjab_Ornaments.Presentation.Viewmodels.HomePage.Customer
{
    public partial class AddNewCustomerPageViewModel : BaseViewModel
    {
        #region private Members
        private string prifix;
        private string firstName;
        private string lastName;
        private string phoneNumber;
        private string address1;
        private string address2;
        private string landMark;
        private string city;
        private string state;
        private string pinCode;
        #endregion
        #region Commands
        public ICommand AddCustomerCommand => new Command(async () => await AddCustomerAsync());
        #endregion

        #region Constructor and initial functions
        public AddNewCustomerPageViewModel(IDataService localDataService, INavigationService navigationservice) : base(localDataService, navigationservice)
        {
        }
        #endregion

        #region BindableProperties
        public string Prifix
        {
            get => prifix;
            set
            {
                prifix = value;
                OnPropertyChanged();
            }
        }
        public string FirstName
        {
            get => firstName;
            set
            {
                firstName = value;
                OnPropertyChanged();
            }
        }
        public string LastName
        {
            get => lastName;
            set
            {
                lastName = value;
                OnPropertyChanged();
            }
        }
        public string PhoneNumber
        {
            get => phoneNumber;
            set
            {
                phoneNumber = value;
                OnPropertyChanged(nameof(PhoneNumber));
            }
        }
        public string Address1
        {
            get => address1;
            set
            {
                address1 = value;
                OnPropertyChanged(nameof(Address1));
            }
        }
        public string Address2
        {
            get => address2;
            set
            {
                address2 = value;
                OnPropertyChanged();
            }
        }
        public string LandMark
        {
            get => landMark;
            set
            {
                landMark = value;
                OnPropertyChanged();
            }
        }
        public string City
        {
            get => city;
            set
            {
                city = value;
                OnPropertyChanged();
            }
        }
        public string State
        {
            get => state;
            set
            {
                state = value;
                OnPropertyChanged();
            }
        }
        public string PinCode
        {
            get => pinCode;
            set
            {
                pinCode = value;
                OnPropertyChanged();
            }
        }
        #endregion
        
        async Task AddCustomerAsync()
        {
            Models.Customer customer = new()
            {
                CustmorPrifix = Prifix,
                CustmorFirstName = FirstName,
                CustmorLastName = LastName,
                CustmorPhoneNumber = PhoneNumber,
                CustmorAddress1 = Address1,
                CustmorAddress2 = Address2,
                CustmorLandMark = LandMark,
                CustmorCity = City,
                CustmorState = State,
                CustmorPinCode = PinCode,

            };
            await _dataService.AddCustomer(customer);
            await _navigationService.PopAsync();
        }

    }
}
