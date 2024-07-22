using Punjab_Ornaments.Models;
using Sonaar.Models.Auth;

namespace Sonaar.Infrastructure.Database
{
    public interface IDataService
    {
        void Initialize();

        #region auth
        Task<ResponseResult<LoginUser>> LoginUser(string username, string password);

        #endregion
    }
}
