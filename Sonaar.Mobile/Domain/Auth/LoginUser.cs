namespace Sonaar.Domain.Auth
{
    public class LoginUser : Sonaar.Common.Models.Auth.AuthUser
    {
        public bool IsUserloggedin => !string.IsNullOrEmpty(Token);
    }
}