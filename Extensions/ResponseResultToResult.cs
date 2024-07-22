using Sonaar.Models.Auth;
using Punjab_Ornaments.Models;

namespace Sonaar.Extensions
{
    public static class ResponseResultToResult
    {
        public static LoginUser ToResult(this ResponseResult<LoginUser> responseResult)
        {
            return responseResult.Data;
        }
    }
}
