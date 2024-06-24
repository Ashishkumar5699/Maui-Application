using System;
using Sonaar.Mobile.RestBridge.RestService;
using Sonaar.Common.Models.Response;
using Sonaar.Mobile.Models.Auth;
using Sonaar.Mobile.RestBridge.Urls;

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
                response.Message = Sonaar.Common.Constants.GlobalMessages.InvalidUsername;
                return response;
            }

            if (string.IsNullOrEmpty(loginUser.Password))
            {
                response.Message = Sonaar.Common.Constants.GlobalMessages.InvalidPassword;
                return response;
            }

            response = await _restService.PostAsync(ApiConstant.Login, loginUser, response);
            //response.Message ??= Preferences.Get(PreferenceConstant.LastError, PreferenceConstant.Default);
            return response;
        }
    }
}

