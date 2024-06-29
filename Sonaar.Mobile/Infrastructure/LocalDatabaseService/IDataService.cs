using Sonaar.Domain;
using Sonaar.Domain.Approvals;
using Sonaar.Domain.Auth;
using Sonaar.Domain.Customer;
using Sonaar.Domain.Products;
using Sonaar.Domain.Products.Details;
using Sonaar.Common.Bills;
using Sonaar.Common.Models.Response;

namespace Sonaar.Infrastructure.Database
{
    public interface IDataService
    {
        void Initialize();

        #region auth
        Task<ResponseResult<LoginUser>> LoginUser(string username, string password);

        #endregion

        #region GoldSection
        Task<int> AddGoldinStock(Gold gold);
        Task<int> UpdateGoldinStock(Gold gold);
        Task<int> DeleteGoldFromStock(Gold gold);
        Task<List<Gold>> GetAllGoldStock();
        Task<List<Gold>> GetGoldStockById(int id);
        #endregion

        #region Approval Section

        Task<List<PurchaseRequest>> GetAllPendingPurchaseRequests();
        Task<List<PurchaseRequest>> GetAllCompletePurchaseRequests();
        #endregion

        #region CustomerSection
        Task<int> AddCustomer(Customer customer);
        Task<int> UpdateCustpmer(Customer customer);
        Task<int> DeleteCustomer(Customer customer);
        Task<List<Customer>> GetAllCustomers();
        Task<List<Customer>> GetCustomerByPhone(int phone);
        #endregion

        #region PurchaseSection
        Task<int> AddPurchase(PurchaseRequest Purchaseitem);
        Task<int> UpdatePurchase(PurchaseRequest Purchaseitem);
        Task<int> DeletePurchase(PurchaseRequest Purchaseitem);
        Task<List<PurchaseRequest>> GetAllPendingPurchases();
        Task<List<PurchaseRequest>> GetAllCompletePurchases();
        Task<List<PurchaseRequest>> GetTodaysPurchase();
        Task<List<PurchaseRequest>> GetPurchaseById(int purchaseid);
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

        #region QuickSale
        public Task<ResponseResult<byte[]>> GenerateQuotation(PrintBillModel printBillModel);
        #endregion
    }
}
