using CommunityToolkit.Maui.Core;
using Punjab_Ornaments.Models;
using Sonaar.Infrastructure.AlertService;
using Sonaar.Infrastructure.APIService;
using Sonaar.Infrastructure.Database;
using Sonaar.Models.Auth;

namespace Sonaar.Localization.Database
{
    public class RESTDataService : IDataService
    {
       #region initialization
        public readonly IAPIService _iAPIService;
        protected readonly IAlertService _alertService;

        public RESTDataService(IAPIService apiService, IAlertService alertService)
        {
            _iAPIService = apiService;
            _alertService = alertService;
        }
        public void Initialize()
        {

        }

        public async Task<ResponseResult<LoginUser>> LoginUser(string username, string password)
        {

            var result = await _iAPIService.LoginUser(new LoginUser
            {    
                UserName = username,
                Password = password
            });

            ToastDuration duration = result.HasErrors || result.IsSystemError ? ToastDuration.Long : ToastDuration.Short;

            await _alertService.ShowAlert(result.Message, duration, 14);

            return result;
        }
     
        #endregion

    }
}