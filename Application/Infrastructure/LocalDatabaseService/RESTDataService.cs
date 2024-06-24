using CommunityToolkit.Maui.Core;
using Sonaar.Infrastructure.AlertService;
using Sonaar.Infrastructure.APIService;
using Sonaar.Infrastructure.Database;
using Sonaar.Domain;
using Sonaar.Domain.Approvals;
using Sonaar.Domain.Auth;
using Sonaar.Domain.Products.Details;
using Sonaar.Common.Models.Response;
using Sonaar.Domain.Products;
using Sonaar.Domain.Customer;
using Sonaar.Common.Bills;

namespace Sonaar.Localization.Database
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
        #endregion

        #region Auth
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
        #endregion
        #region gold
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
        #endregion

        #region Approval
        public Task<List<PurchaseRequest>> GetAllPendingPurchaseRequests()
        {
            throw new NotImplementedException();
        }

        public Task<List<PurchaseRequest>> GetAllCompletePurchaseRequests()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region consumer
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

        #endregion

        #region Request
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
        #endregion

        #region metal
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

        #region Quicksale
        public async Task<ResponseResult<byte[]>> GenerateQuotation(PrintBillModel printBillModel)
        {
            var result = await _iAPIService.GenerateQuotation(printBillModel);

            ToastDuration duration = result.HasErrors || result.IsSystemError ? ToastDuration.Long : ToastDuration.Short;
            await _alertService.ShowAlert(result.Message, duration, 14);
            return result;
        }
        #endregion

    }
}