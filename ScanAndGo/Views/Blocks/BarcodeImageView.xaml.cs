using System;
using System.Collections.Generic;
using ScanAndGo.ViewModels.Blocks;
using Xamarin.Forms;

namespace ScanAndGo.Views.Blocks
{
    public partial class BarcodeImageView : ContentView
    {
        public BarcodeImageView()
        {
            InitializeComponent();
            this.BindingContextChanged += Handle_BindingContextChanged; 
        }

        void Handle_BindingContextChanged(object sender, EventArgs e)
        {
            if(this.BindingContext is BarcodeImageViewModel)
            {
               var viewModel =  this.BindingContext as BarcodeImageViewModel;
                var height = viewModel.Height;
                var width = viewModel.Width;
                this.barcodeImageView.BarcodeOptions = new ZXing.Common.EncodingOptions
                {
                    Height = (int)height,
                    Width = (int)width
                };
            }
        }

    }
}
