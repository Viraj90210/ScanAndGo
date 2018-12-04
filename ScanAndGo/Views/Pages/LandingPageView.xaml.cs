using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace ScanAndGo.Views.Pages
{
    public partial class LandingPageView : ContentPage
    {
        public LandingPageView()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            Title = "Scan";
        }
    }
}
