using Punjab_Ornaments.Domain.Auth;
using PunjabOrnaments.Common.Models.Response;
namespace Punjab_Ornaments.Extensions
{
    public static class ResponseResultToResult
    {
        public static LoginUser ToResult(this ResponseResult<LoginUser> responseResult)
        {
            return responseResult.Data;
        }
    }
}
