using CommunityToolkit.Maui.Core;
using Punjab_Ornaments.Infrastructure.AlertService;
using Punjab_Ornaments.Infrastructure.APIService;
using Punjab_Ornaments.Infrastructure.Database;
using Punjab_Ornaments.Models;
using Punjab_Ornaments.Models.Approvals;
using Punjab_Ornaments.Models.Auth;
using Punjab_Ornaments.Models.Products.Details;
using PunjabOrnaments.Common.Models.Response;

namespace Punjab_Ornaments.Localization.Database
{
    public class RESTDataService : IDataService
    {
       #region initialization
        public readonly IAPIService _iAPIService;
        protected readonly IAlertService _alertService;

        public RESTDataService(IAPIService apiService, IAlertService alertService)
        {
            _iAPIService = apiService;
            _alertService = alertService;
        }
        public void Initialize()
        {

        }

        public async Task<ResponseResult<LoginUser>> LoginUser(string username, string password)
        {

            var result = await _iAPIService.LoginUser(new LoginUser
            {    
                UserName = username,
                Password = password
            });

            ToastDuration duration = result.HasErrors || result.IsSystemError ? ToastDuration.Long : ToastDuration.Short;

            await _alertService.ShowAlert(result.Message, duration, 14);

            return result;
        }

        public Task<int> AddGoldinStock(Gold gold)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateGoldinStock(Gold gold)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteGoldFromStock(Gold gold)
        {
            throw new NotImplementedException();
        }

        public Task<List<Gold>> GetAllGoldStock()
        {
            throw new NotImplementedException();
        }

        public Task<List<Gold>> GetGoldStockById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<PurchaseRequest>> GetAllPendingPurchaseRequests()
        {
            throw new NotImplementedException();
        }

        public Task<List<PurchaseRequest>> GetAllCompletePurchaseRequests()
        {
            throw new NotImplementedException();
        }

        public Task<int> AddCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateCustpmer(Customer customer)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }

        public Task<List<Customer>> GetAllCustomers()
        {
            throw new NotImplementedException();
        }

        public Task<List<Customer>> GetCustomerByPhone(int phone)
        {
            throw new NotImplementedException();
        }

        public Task<int> AddPurchase(PurchaseRequest Purchaseitem)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdatePurchase(PurchaseRequest Purchaseitem)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeletePurchase(PurchaseRequest Purchaseitem)
        {
            throw new NotImplementedException();
        }

        public Task<List<PurchaseRequest>> GetAllPendingPurchases()
        {
            throw new NotImplementedException();
        }

        public Task<List<PurchaseRequest>> GetAllCompletePurchases()
        {
            throw new NotImplementedException();
        }

        public Task<List<PurchaseRequest>> GetTodaysPurchase()
        {
            throw new NotImplementedException();
        }

        public Task<List<PurchaseRequest>> GetPurchaseById(int purchaseid)
        {
            throw new NotImplementedException();
        }

        public Task<int> ApprovedPurchase(int purchaseid, int isapproved)
        {
            throw new NotImplementedException();
        }

        public Task<int> AddMetalType(Discriptions metelType)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteMetalType(Discriptions metelType)
        {
            throw new NotImplementedException();
        }

        public Task<List<Discriptions>> GetAllMetalType()
        {
            throw new NotImplementedException();
        }

        public Task<int> AddBrand(Discriptions brand)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteBrand(Discriptions brand)
        {
            throw new NotImplementedException();
        }

        public Task<List<Discriptions>> GetAllBrand()
        {
            throw new NotImplementedException();
        }

        public Task<List<Discriptions>> GetBrandByMetalType(string metalType)
        {
            throw new NotImplementedException();
        }
        #endregion

    }
}
//    public class RESTDataService : IDataService
//    {


//        #region Gold
//        public  Task<int> AddGoldinStock(Gold gold) => throw new NotImplementedException();
//        public Task<int> UpdateGoldinStock(Gold gold) => throw new NotImplementedException();
//        public Task<int> DeleteGoldFromStock(Gold gold) => throw new NotImplementedException();
//        public Task<List<Gold>> GetAllGoldStock() => throw new NotImplementedException();
//        public Task<List<Gold>> GetGoldStockById(int id) => throw new NotImplementedException();
//        #endregion

//        #region Customer
//        public Task<int> AddCustomer(Customer custmor) => throw new NotImplementedException();
//        public Task<int> UpdateCustpmer(Customer custmor) => throw new NotImplementedException();
//        public Task<int> DeleteCustomer(Customer custmor) => throw new NotImplementedException();
//        public Task<List<Customer>> GetAllCustomers() => throw new NotImplementedException();
//        public Task<List<Customer>> GetCustomerByPhone(int phoneNumber) => throw new NotImplementedException();
//        #endregion

//        #region Purchase
//        public Task<int> AddPurchase(PurchaseRequest Purchaseitem) => throw new NotImplementedException();
//        public Task<int> UpdatePurchase(PurchaseRequest Purchaseitem) => throw new NotImplementedException();
//        public Task<int> DeletePurchase(PurchaseRequest Purchaseitem) => throw new NotImplementedException();
//        public Task<List<PurchaseRequest>> GetAllPendingPurchases() => throw new NotImplementedException();
//        public Task<List<PurchaseRequest>> GetAllCompletePurchases() => throw new NotImplementedException();
//        public Task<List<PurchaseRequest>> GetTodaysPurchase() => throw new NotImplementedException();
//        public Task<List<PurchaseRequest>> GetPurchaseById(int purchaseid) => throw new NotImplementedException();
//        public Task<int> ApprovedPurchase(int purchaseid) => throw new NotImplementedException();
//        #endregion

//        #region MetalTypes
//        public async Task<int> AddMetalType(MetelType metelType) => throw new NotImplementedException();

//        public async Task<int> DeleteMetalType(MetelType metelType) => throw new NotImplementedException();

//        public async Task<List<MetelType>> GetAllMetalType() => throw new NotImplementedException();
//        #endregion

//        #region Brands
//        public async Task<int> AddBrand(Discriptions brand) => throw new NotImplementedException();

//        public async Task<int> DeleteBrand(Discriptions brand) => throw new NotImplementedException();

//        public async Task<List<Discriptions>> GetAllBrand() => throw new NotImplementedException();

//        public async Task<List<Discriptions>> GetBrandByMetalType(string metalType) => throw new NotImplementedException();

//        public Task<List<Purchase>> GetAllPendingPurchaseRequests()
//        {
//            throw new NotImplementedException();
//        }

//        public Task<List<Purchase>> GetAllCompletePurchaseRequests()
//        {
//            throw new NotImplementedException();
//        }

//        public Task<int> ApprovedPurchase(int purchaseid, int isapproved)
//        {
//            throw new NotImplementedException();
//        }

//        Task<List<PurchaseRequest>> IDataService.GetAllPendingPurchaseRequests()
//        {
//            throw new NotImplementedException();
//        }

//        Task<List<PurchaseRequest>> IDataService.GetAllCompletePurchaseRequests()
//        {
//            throw new NotImplementedException();
//        }

//        Task<List<Discriptions>> IDataService.GetAllBrand()
//        {
//            throw new NotImplementedException();
//        }

//        Task<List<Discriptions>> IDataService.GetBrandByMetalType(string metalType)
//        {
//            throw new NotImplementedException();
//        }

//        #endregion
//    }
//}