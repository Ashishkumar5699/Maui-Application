﻿using Sonaar.Resources.Constant;
using Sonaar.Mobile.RestBridge.RestService;
using Sonaar.Domain.Response;
using Sonaar.Mobile.Models.Auth;
using Sonaar.Domain.Constants;

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
                response.Message = GlobalMessages.InvalidUsername;
                return response;
            }

            if (string.IsNullOrEmpty(loginUser.Password))
            {
                response.Message = GlobalMessages.InvalidPassword;
                return response;
            }

            response = await _restService.PostAsync(ApiConstant.Login, loginUser, response);
            response.Message ??= Preferences.Get(PreferenceConstant.LastError, PreferenceConstant.Default);
            return response;
        }

        //public async Task AddGoldPurchaseRequst(Domain.Approvals.PurchaseRequest request)
        //{
        //   var responce =  await _restService.PutAsync(ApiConstant.AddPurchaseRequest, request);
        //}

        //public async Task<List<Domain.Approvals.PurchaseRequest>> GetAllPurchaseRequest()
        //{
        //    //var response = await _restService.GetAsync<List<Domain.Purchase.PurchaseResponse>>(ApiConstant.GetAllGoldPurchaseRequests, "", null);
        //    var response = await _restService.GetAsync<List<Domain.Approvals.PurchaseRequest>>(ApiConstant.GetAllGoldPurchaseRequests, new List<Domain.Approvals.PurchaseRequest>(), null);
        //    return new List<Domain.Approvals.PurchaseRequest>(response);
        //}

        //public async Task<bool> GoldApprove(int id)
        //{
        //    var response = await _restService.PutAsync<Domain.Approvals.PurchaseRequest>(ApiConstant.GoldApprove + id.ToString(), null);
        //    return response != null;
        //}
        //public async Task<bool> GoldReject(int id)
        //{
        //    var response = await _restService.PutAsync<Domain.Approvals.PurchaseRequest>(ApiConstant.GoldReject + id.ToString(), null);
        //    return response != null;
        //}

        //public async Task<Domain.Approvals.PurchaseRequest> GetPurchaseById(int id)
        //{
        //    var response = await _restService.GetAsync<Domain.Approvals.PurchaseRequest>(ApiConstant.GetGoldRequestDetail + id.ToString(), new Domain.Approvals.PurchaseRequest(), "", null);
        //    return response;
        //}
    }
}
