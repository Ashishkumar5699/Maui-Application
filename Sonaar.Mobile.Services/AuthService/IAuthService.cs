using System;
using Sonaar.Domain.Response;
using Sonaar.Mobile.Models.Auth;

namespace Sonaar.Mobile.Services.AuthService
{
	public interface IAuthService
	{
        Task<ResponseResult<LoginUser>> LoginUser(string username, string password);
    }
}

