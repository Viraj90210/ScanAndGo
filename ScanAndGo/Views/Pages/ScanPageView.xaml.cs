using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace ScanAndGo.Views.Pages
{
    public partial class ScanPageView : ContentPage
    {
        public ScanPageView()
        {
            InitializeComponent();
            if (Device.RuntimePlatform == Device.iOS)
            {
                Padding = new Thickness(0, 20, 0, 0);
            }
        }
    }
}
