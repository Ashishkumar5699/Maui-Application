
using Punjab_Ornaments.Models;
using Sonaar.Models.Auth;

namespace Sonaar.Infrastructure.APIService
{
    public interface IAPIService
    {
        #region Auth
        Task<ResponseResult<LoginUser>> LoginUser(LoginUser loginUser);
        #endregion
    }
}
