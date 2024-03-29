
using Punjab_Ornaments.Models.Auth;

namespace Punjab_Ornaments.Infrastructure.APIService
{
    public interface IAPIService
    {
        #region Auth
        Task<PunjabOrnaments.Common.Models.Response.ResponseResult<LoginUser>> LoginUser(LoginUser loginUser);
        #endregion
        Task AddGoldPurchaseRequst(Models.Approvals.PurchaseRequest request);
        Task<List<Models.Approvals.PurchaseRequest>> GetAllPurchaseRequest();
        Task<bool> GoldApprove(int id);
        Task<bool> GoldReject(int id);
        Task<Models.Approvals.PurchaseRequest> GetPurchaseById(int id);
    }
}
