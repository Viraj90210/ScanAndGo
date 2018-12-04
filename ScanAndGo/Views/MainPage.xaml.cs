using System;
using ScanAndGo.Views.Cart;
using ScanAndGo.Views.Pages;
using ScanAndGo.Views.Product;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ScanAndGo.Views {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : TabbedPage {
        public MainPage(string barcodeValue) {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            //Children.Add(new LandingPageView());
            Children.Add(new ProductDisplayPage(barcodeValue));
            Children.Add(new CartPage());
            Children.Add(new AboutPage());
        }
    }
}