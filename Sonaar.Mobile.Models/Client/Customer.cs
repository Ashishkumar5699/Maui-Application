using CommunityToolkit.Mvvm.ComponentModel;
using Sonaar.Domain.Enum;

namespace Sonaar.Mobile.Models.Client
{
    public partial class Customer : ObservableObject
    {
        public int ContactId { get; set; }

        public string ContactPrifix { get; set; }

        [ObservableProperty]
        string contactFirstName;

        public string ContactLastName { get; set; }

        [ObservableProperty]
        string contactPhoneNumber;

        [ObservableProperty]
        string contactAddress1;

        public string ContactAddress2 { get; set; }

        public string ContactLandMark { get; set; }

        [ObservableProperty]
        string contactCity;

        [ObservableProperty]
        string contactState;

        public string ContactPinCode { get; set; }

        [ObservableProperty]
        string adharNumber;

        public string PanNumber { get; set; }

        public string CustmorGSTNumber { get; set; }

        [ObservableProperty]
        string custmorCountry;

        [ObservableProperty]
        string custmorZipCode;

        public ContactType ContactType { get; set; }
    }
}

