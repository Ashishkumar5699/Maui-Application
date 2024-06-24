
using Sonaar.Domain.Auth;
using Sonaar.Domain.Approvals;
using Sonaar.Common.Bills;
using Sonaar.Common.Models.Response;

namespace Sonaar.Infrastructure.APIService
{
    public interface IAPIService
    {
        #region Auth
        Task<ResponseResult<LoginUser>> LoginUser(LoginUser loginUser);
        #endregion

        #region Approvel
        Task AddGoldPurchaseRequst(Domain.Approvals.PurchaseRequest request);
        Task<List<PurchaseRequest>> GetAllPurchaseRequest();
        Task<bool> GoldApprove(int id);
        Task<bool> GoldReject(int id);
        Task<PurchaseRequest> GetPurchaseById(int id);
        #endregion

        #region QuickSale
        public Task<ResponseResult<byte[]>> GenerateQuotation(PrintBillModel printBillModel);
        #endregion
    }
}
