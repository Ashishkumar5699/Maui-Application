using System;
using PunjabOrnaments.Common.Models.Response;
using Sonaar.Mobile.Models.Auth;
using Sonaar.Services.BusinessLayer.Auth;

namespace Sonaar.Mobile.Services.AuthService
{
    public class AuthService : IAuthService
    {
        private readonly IAuthProvider _restService;

        public AuthService(IAuthProvider restService)
        {
            _restService = restService;
        }

        public async Task<ResponseResult<LoginUser>> LoginUser(string username, string password)
        {

            var result = await _restService.LoginUser(new LoginUser
            {
                UserName = username,
                Password = password
            });

            //ToastDuration duration = result.HasErrors || result.IsSystemError ? ToastDuration.Long : ToastDuration.Short;

            //await _alertService.ShowAlert(result.Message, duration, 14);

            return result;
        }
    }
}

