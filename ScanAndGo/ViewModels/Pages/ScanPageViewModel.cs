using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace ScanAndGo.ViewModels.Pages
{
    public class ScanPageViewModel : BaseViewModel
    {
        public event EventHandler<string> BarcodeScanned;

        public ScanPageViewModel()
        {
            barcodeText = string.Empty;
            IsScanning = true;
            ScanCompletedCommand = new Command((barcodeText) =>
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    IsScanning = false;
                    Application.Current.MainPage.Navigation.PopModalAsync();
                    BarcodeText = barcodeText?.ToString();
                    BarcodeScanned?.Invoke(this, barcodeText?.ToString());
                });
            });
            CompletedCommand = new Command(() =>
            {
                if(!string.IsNullOrEmpty(BarcodeText))
                {
                    IsScanning = false;
                    Application.Current.MainPage.Navigation.PopModalAsync();
                    BarcodeScanned?.Invoke(this, barcodeText?.ToString());
                }
            });
            FlashCommand = new Command(() =>
            {
                if(flashOn)
                {
                    FlashImageSource = ImageSource.FromFile("ic_flash_off.png");
                }
                else
                {
                    FlashImageSource = ImageSource.FromFile("ic_flash_on.png");
                }
                FlashOn = !FlashOn;
            });
            CloseCommand = new Command(() =>
            {
                IsScanning = false;
                Application.Current.MainPage.Navigation.PopModalAsync();
            });
        }

        string barcodeText;
        public string BarcodeText
        {
            get { return barcodeText; }
            set { SetProperty(ref barcodeText, value); }
        }

        public ICommand ScanCompletedCommand
        {
            get;
            set;
        }

        public ICommand CompletedCommand { get; set; }

        public ICommand FlashCommand
        {
            get;
            set;
        }

        public ICommand CloseCommand
        {
            get;
            set;
        }

        bool flashOn;
        public bool FlashOn
        {
            get { return flashOn; }
            set { SetProperty(ref flashOn, value); }
        }

        bool isScanning;
        public bool IsScanning
        {
            get { return isScanning; }
            set { SetProperty(ref isScanning, value); }
        }

        ImageSource flashImageSource = ImageSource.FromFile("ic_flash_off.png");
        public ImageSource FlashImageSource
        {
            get { return flashImageSource; }
            set { SetProperty(ref flashImageSource, value); }
        }
    }
}
