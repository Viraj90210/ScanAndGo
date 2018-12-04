using System;
using System.Windows.Input;
using ScanAndGo.ViewModels.Blocks;
using Xamarin.Forms;

namespace ScanAndGo.ViewModels.Pages
{
    public class PaymentBarcodePageViewModel : BaseViewModel
    {
        public PaymentBarcodePageViewModel(string barcodeValue)
        {
            BarcodeImageViewContext = new BarcodeImageViewModel
            {
                BarcodeText = barcodeValue,
                BarcodeInstructions = "Scan the QR code at Scan and Go lane for final checkout",
            };
            HomeCommand = new Command(async () =>
            {
                await Application.Current.MainPage.Navigation.PopToRootAsync();
            });
        }

        BarcodeImageViewModel barcodeImageViewModel;
        public BarcodeImageViewModel BarcodeImageViewContext
        {
            get { return barcodeImageViewModel; }
            set { SetProperty(ref barcodeImageViewModel, value); }
        }

        public ICommand HomeCommand
        {
            get;
            set;
        }
    }
}

