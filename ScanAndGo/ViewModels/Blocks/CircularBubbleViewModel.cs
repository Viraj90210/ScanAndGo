using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace ScanAndGo.ViewModels.Blocks
{
    public class CircularBubbleViewModel : BaseViewModel
    {
        public ICommand Command
        {
            get;
            set;
        }

        string text = string.Empty;
        public string Text
        {
            get { return text; }
            set { SetProperty(ref text, value); }
        }

        ImageSource imageSource;
        public ImageSource ImageSource
        {
            get { return imageSource; }
            set { SetProperty(ref imageSource, value); }
        }
    }
}

