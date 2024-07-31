using System;
using System.ComponentModel.DataAnnotations;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Sonaar.Mobile.Models.Auth
{
	public class LoginUser : ObservableObject
    {

        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }

        public string Token { get; set; }

        public string Device { get; set; } = "Mobile";

        public bool IsUserloggedin => !string.IsNullOrEmpty(Token);

    }
}

