﻿using System;
using Sonaar.Domain.Response;
using Sonaar.Mobile.Models.Auth;

namespace Sonaar.Services.BusinessLayer.Auth
{
	public interface IAuthProvider
	{
        Task<ResponseResult<LoginUser>> LoginUser(LoginUser loginUser);
    }
}

