namespace Punjab_Ornaments.Resources.Constant
{
    public static class ApiConstant
    {
        public const string url = "http://localhost:5000";
        public const string base_url = url + "api/";

        #region Account
        public const string Login = base_url + "account/login";
        public const string Register = base_url + "account/register";
        #endregion

        #region Stock
        public const string GetAllStock = base_url + "Stock";
        #endregion

        #region Request
        public const string AddPurchaseRequest = base_url + "Request/AddGoldPurchaseRequst";
        public const string GetGoldRequestDetail = base_url + "Request/GetGoldRequestDetail/";
        public const string DeleteGoldPurchaseRequst = base_url + "Request/DeleteGoldPurchaseRequst/";
        #endregion

        #region Approval
        public const string GetAllGoldPurchaseRequests = base_url + "Approval/Getallgoldpurchaserequests";
        public const string GoldApprove = base_url + "Approval/GoldApprove/";
        public const string GoldReject = base_url + "Approval/GoldReject/";
        #endregion
    }
}
