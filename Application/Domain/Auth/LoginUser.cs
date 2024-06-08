namespace Punjab_Ornaments.Domain.Auth
{
    public class LoginUser : PunjabOrnaments.Common.Models.Auth.AuthUser
    {
        public bool IsUserloggedin => !string.IsNullOrEmpty(Token);
    }
}