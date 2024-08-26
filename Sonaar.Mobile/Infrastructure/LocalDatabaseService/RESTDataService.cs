using CommunityToolkit.Maui.Core;
using Sonaar.Infrastructure.AlertService;
using Sonaar.Infrastructure.APIService;
using Sonaar.Infrastructure.Database;
using Sonaar.Domain.Approvals;
using Sonaar.Domain.Products.Details;
using Sonaar.Domain.Response;
using Sonaar.Domain.Products;
using Sonaar.Mobile.Models.Auth;

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

        public async Task<List<Gold>> GetAllGoldStock()
        {
            await Task.Delay(200);
            return new List<Gold>();
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


    }
}