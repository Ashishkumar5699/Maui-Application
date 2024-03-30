using Punjab_Ornaments.Models;
using Punjab_Ornaments.Models.Auth;
using Punjab_Ornaments.Models.Products.Details;

namespace Punjab_Ornaments.Infrastructure.Database
{
    public interface IDataService
    {
        void Initialize();

        #region auth
        Task<PunjabOrnaments.Common.Models.Response.ResponseResult<LoginUser>> LoginUser(string username, string password);

        #endregion

        #region GoldSection
        Task<int> AddGoldinStock(Gold gold);
        Task<int> UpdateGoldinStock(Gold gold);
        Task<int> DeleteGoldFromStock(Gold gold);
        Task<List<Gold>> GetAllGoldStock();
        Task<List<Gold>> GetGoldStockById(int id);
        #endregion

        #region Approval Section

        Task<List<Models.Approvals.PurchaseRequest>> GetAllPendingPurchaseRequests();
        Task<List<Models.Approvals.PurchaseRequest>> GetAllCompletePurchaseRequests();
        #endregion

        #region CustomerSection
        Task<int> AddCustomer(Customer customer);
        Task<int> UpdateCustpmer(Customer customer);
        Task<int> DeleteCustomer(Customer customer);
        Task<List<Customer>> GetAllCustomers();
        Task<List<Customer>> GetCustomerByPhone(int phone);
        #endregion

        #region PurchaseSection
        Task<int> AddPurchase(Models.Approvals.PurchaseRequest Purchaseitem);
        Task<int> UpdatePurchase(Models.Approvals.PurchaseRequest Purchaseitem);
        Task<int> DeletePurchase(Models.Approvals.PurchaseRequest Purchaseitem);
        Task<List<Models.Approvals.PurchaseRequest>> GetAllPendingPurchases();
        Task<List<Models.Approvals.PurchaseRequest>> GetAllCompletePurchases();
        Task<List<Models.Approvals.PurchaseRequest>> GetTodaysPurchase();
        Task<List<Models.Approvals.PurchaseRequest>> GetPurchaseById(int purchaseid);
        Task<int> ApprovedPurchase(int purchaseid, int isapproved);
        #endregion

        #region Admin Pannel (Setting)

        #region MetalType
        Task<int> AddMetalType(Discriptions metelType);
        Task<int> DeleteMetalType(Discriptions metelType);
        Task<List<Discriptions>> GetAllMetalType();
        #endregion

        #region Brand
        Task<int> AddBrand(Discriptions brand);
        Task<int> DeleteBrand(Discriptions brand);
        Task<List<Discriptions>> GetAllBrand();
        Task<List<Discriptions>> GetBrandByMetalType(string metalType);
        #endregion

        #endregion
    }
}
