using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ScanAndGo.Views.Animatation;
using ScanAndGo.Models;
using System.Collections.Generic;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace ScanAndGo {
    public partial class App : Application 
    {
        public static IList<ProductModel> ProductsInCart { get; set; }= new List<ProductModel>();

        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new AnimatationPage());
            //MainPage = new NavigationPage(new LandingPageView(){BindingContext = new LandingPageViewModel()});
        }

        protected override void OnStart() {
            // Handle when your app starts
        }

        protected override void OnSleep() {
            // Handle when your app sleeps
        }

        protected override void OnResume() {
            // Handle when your app resumes
        }
    }
}
