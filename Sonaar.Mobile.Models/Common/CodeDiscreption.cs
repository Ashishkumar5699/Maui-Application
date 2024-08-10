using System;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Sonaar.Mobile.Models.Common
{
    public class CodeDiscreption : ObservableObject
    {
        public string Code { get; set; }

        public string Discreption { get; set; }
    }
}

