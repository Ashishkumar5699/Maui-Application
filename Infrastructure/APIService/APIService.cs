using Sonaar.Infrastructure.RestService;
using Sonaar.Models.Auth;
using Sonaar.Resources.Constant;
using Punjab_Ornaments.Models;

namespace Sonaar.Infrastructure.APIService
{
    public class APIService : IAPIService
    {
        private readonly IRestService _restService;
        public APIService(IRestService restService)
        {
            _restService = restService;
        }

        public async Task<ResponseResult<LoginUser>> LoginUser(LoginUser loginUser)
        {
            var response = new ResponseResult<LoginUser>
            {
                HasErrors = true,
                IsSystemError = true,
            };

            if (string.IsNullOrEmpty(loginUser.UserName))
            {
                response.Message = "Invalid Username";
                return response;
            }

            if (string.IsNullOrEmpty(loginUser.Password))
            {
                response.Message = "Invalid Password";
                return response;
            }

            response = await _restService.PostAsync(ApiConstant.Login, loginUser, response);
            response.Message ??= Preferences.Get(PreferenceConstant.LastError, PreferenceConstant.Default);
            return response;
        }
    }
}
