
using Punjab_Ornaments.Domain.Auth;
using Punjab_Ornaments.Domain.Approvals;
using PunjabOrnaments.Common.Bills;
using PunjabOrnaments.Common.Models.Response;

namespace Punjab_Ornaments.Infrastructure.APIService
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
