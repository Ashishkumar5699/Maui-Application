using Sonaar.Mobile.RestBridge.RestService;
using Sonaar.Mobile.Models.Auth;
using Sonaar.Mobile.RestBridge.Urls;
using Sonaar.Domain.Constants;
using Sonaar.Domain.Response;

namespace Sonaar.Services.BusinessLayer.Auth
{
    public class AuthProvider : IAuthProvider
    {
        private readonly IRestService _restService;
        public AuthProvider(IRestService restService)
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
                response.Message = GlobalMessages.InvalidUsername;
                return response;
            }

            if (string.IsNullOrEmpty(loginUser.Password))
            {
                response.Message = GlobalMessages.InvalidPassword;
                return response;
            }

            response = await _restService.PostAsync(ApiConstant.Login, loginUser, response);
            //response.Message ??= Preferences.Get(PreferenceConstant.LastError, PreferenceConstant.Default);
            return response;
        }
    }
}

