using System;

using Xamarin.Forms;

namespace ScanAndGo.ViewModels.Blocks
{
    public class BarcodeImageViewModel :  BaseViewModel
    {
        string barcodeText = string.Empty;
        public string BarcodeText
        {
            get { return barcodeText; }
            set { SetProperty(ref barcodeText, value); }
        }

        string barcodeInstructions = string.Empty;
        public string BarcodeInstructions
        {
            get { return barcodeInstructions; }
            set { SetProperty(ref barcodeInstructions, value); }
        }

        double height = 375;
        public double Height
        {
            get { return height; }
            set { SetProperty(ref height, value); }
        }

        double width = 375;
        public double Width
        {
            get { return width; }
            set { SetProperty(ref width, value); }
        }
    }
}

