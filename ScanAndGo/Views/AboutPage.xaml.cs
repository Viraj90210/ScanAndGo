using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ScanAndGo.Views {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AboutPage : ContentPage {
        public AboutPage() {
            InitializeComponent();
            if (Device.RuntimePlatform == Device.iOS) {
                Icon = "tab_about.png";
            }
        }
    }
}