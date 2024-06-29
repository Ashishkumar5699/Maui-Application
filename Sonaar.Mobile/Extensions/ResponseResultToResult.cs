using Sonaar.Domain.Auth;
using Sonaar.Common.Models.Response;
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
