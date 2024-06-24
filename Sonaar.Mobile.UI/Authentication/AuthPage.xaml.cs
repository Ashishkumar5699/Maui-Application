using System;
using Microsoft.Maui.Controls;
using Sonaar.Mobile.UI.Common;

namespace Sonaar.Mobile.UI.Authentication;

public partial class AuthPage : ContentPage
{
	public AuthPage()
	{
		InitializeComponent();
        BindingContext = ServiceHelper.GetService<AuthPageViewModel>();
    }
}
