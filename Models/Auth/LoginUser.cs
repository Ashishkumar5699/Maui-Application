namespace Punjab_Ornaments.Models.Auth
{
    public class LoginUser : PunjabOrnaments.Common.Models.Auth.AuthUser
    {
        public bool IsUserloggedin => !string.IsNullOrEmpty(Token);
    }
}