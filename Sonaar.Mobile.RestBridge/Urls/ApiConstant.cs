using System;
namespace Sonaar.Mobile.RestBridge.Urls
{
	public class ApiConstant
	{
        //public const string url = "https://pnjb.azurewebsites.net/";
        //public const string url = "http://localhost:5000/";

        public const string url = "http://api.pnjb.in/";

        public const string base_url = url + "api/";

        #region Auth

        public const string Login = base_url + "account/login";

        #endregion

        #region Print

        public const string GenerateQuote = base_url + "Pdf/GeneratePDFGPT";

        #endregion
    }
}

