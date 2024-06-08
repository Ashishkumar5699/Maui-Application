
using Punjab_Ornaments.Domain.Auth;
using Punjab_Ornaments.Domain.Approvals;

namespace Punjab_Ornaments.Infrastructure.APIService
{
    public interface IAPIService
    {
        #region Auth
        Task<PunjabOrnaments.Common.Models.Response.ResponseResult<LoginUser>> LoginUser(LoginUser loginUser);
        #endregion

        #region Approvel
        Task AddGoldPurchaseRequst(Domain.Approvals.PurchaseRequest request);
        Task<List<PurchaseRequest>> GetAllPurchaseRequest();
        Task<bool> GoldApprove(int id);
        Task<bool> GoldReject(int id);
        Task<PurchaseRequest> GetPurchaseById(int id);
        #endregion
    }
}
