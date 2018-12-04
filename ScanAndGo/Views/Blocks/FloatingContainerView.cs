using System;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace ScanAndGo.Views.Blocks
{
    public partial class FloatingContainerView : ContentView
    {

        double x, y, screenWidth, screenHeight;

        public FloatingContainerView()
        {
           // InitializeComponent();

            CalculateDisplayMetrics();
            PanGestureRecognizer panGestureRecognizer = new PanGestureRecognizer();
            panGestureRecognizer.PanUpdated += PanGestureRecognizer_PanUpdated;
            this.GestureRecognizers.Add(panGestureRecognizer);
            DeviceDisplay.ScreenMetricsChanged += DeviceDisplay_ScreenMetricsChanged;
        }


        void PanGestureRecognizer_PanUpdated(object sender, PanUpdatedEventArgs e)
        {
            switch (e.StatusType)
            {
                case GestureStatus.Running:
                    // Translate and ensure we don't pan beyond the wrapped user interface element bounds.
                    Content.TranslationX =
                        Math.Max(Math.Min(0, x + e.TotalX), -Math.Abs(Content.Width - screenWidth));
                    Content.TranslationY =
                      Math.Max(Math.Min(0, y + e.TotalY), -Math.Abs(Content.Height - screenHeight));
                    break;

                case GestureStatus.Completed:
                    // Store the translation applied during the pan
                    x = Content.TranslationX;
                    y = Content.TranslationY;
                    break;
            }
        }


        void DeviceDisplay_ScreenMetricsChanged(object sender, ScreenMetricsChangedEventArgs e)
        {
            CalculateDisplayMetrics();
        }

        private void CalculateDisplayMetrics()
        {
            var metrics = DeviceDisplay.ScreenMetrics;
            var widthInPixel = metrics.Width;
            var heightInPixel = metrics.Height;
            var density = metrics.Density;
            screenWidth = (widthInPixel - 0.5f) / density;
            screenHeight = (heightInPixel - 0.5f) / density;
        }
    }
}

