using System;
using ScanAndGo.ViewModels.Blocks;
using ScanAndGo.Views.Pages;
using Xamarin.Forms;

namespace ScanAndGo.ViewModels.Pages
{
    public class LandingPageViewModel : BaseViewModel
    {
        private ScanPageViewModel scanPageViewModel;

        public LandingPageViewModel()
        {
            InitiliazeViewModel();
        }
        public CircularBubbleViewModel ScanProductContext
        {
            get;
            set;
        }

        public CircularBubbleViewModel LocateProductContext
        {
            get;
            set;
        }

        void InitiliazeViewModel()
        {
            ScanProductContext = new CircularBubbleViewModel
            {
                Command = new Command(() =>
                {
                    OnScanCommand();
                }),
                ImageSource = ImageSource.FromFile("barcode.png"),
                Text = "Scan product"
            };
            LocateProductContext = new CircularBubbleViewModel
            {
                Text = "Locate product",
                Command = new Command(() => OnLocateProduct()),
                ImageSource = ImageSource.FromFile("ic_locate_product.png")
            };
        }

        private void OnScanCommand()
        {
            scanPageViewModel = new ScanPageViewModel();
            scanPageViewModel.BarcodeScanned += ScanPageViewModel_BarcodeScanned;
            Application.Current.MainPage.Navigation.PushModalAsync(new ScanPageView
            {
                BindingContext = scanPageViewModel
            });
        }

        void ScanPageViewModel_BarcodeScanned(object sender, string barcodeValue)
        {
           try
            {
                Application.Current.MainPage.Navigation.PushAsync(new PaymentBarcodePageView()
                {
                    BindingContext = new PaymentBarcodePageViewModel(barcodeValue)
                });
                scanPageViewModel.BarcodeScanned -= ScanPageViewModel_BarcodeScanned;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


        private void OnLocateProduct()
        {
            Application.Current.MainPage.DisplayAlert("Locate product", "This feature is coming soon..", "OK");
        }
    }
}
