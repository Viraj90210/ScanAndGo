using System;
using ScanAndGo.DependencyServices;
using ScanAndGo.ViewModels.Pages;
using ScanAndGo.Views.Pages;
using Xamarin.Forms;

namespace ScanAndGo.Views.Animatation {
    public partial class AnimatationPage : ContentPage {
        public AnimatationPage() {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            StartLazerAnimation();
        }

        private async void StartLazerAnimation() {
            await Lazer.TranslateTo(0, 120, 700);
            await Lazer.TranslateTo(0, -120, 700);
            await Lazer.TranslateTo(0, 0, 700);

            await Lazer.TranslateTo(0, 120, 700);
            await Lazer.TranslateTo(0, -120, 700);
            await Lazer.TranslateTo(0, 0, 700);

            PresentNextAnimation();
        }

        void PresentNextAnimation() {
            BarcodeLayout.IsVisible = false;
            Lazer.IsVisible = false;
            DoneLayout.IsVisible = true;
            StartDoneAnimation();
        }

        private async void StartDoneAnimation() {
            Rotate();
            Scale();
        }

        async new void Rotate() {
            await DoneImg.RotateTo(360, 500);
            await DoneImg.RotateTo(360, 500);
            await DoneImg.RotateTo(360, 500);
            await DoneImg.RotateTo(360, 500);
            await DoneImg.RotateTo(360, 500);
            await DoneImg.RotateTo(360, 500);
            await DoneImg.RotateTo(360, 500);
            await DoneImg.RotateTo(360, 500);
        }

        async new void Scale() {
            await DoneImg.ScaleTo(0.1);
            await DoneImg.ScaleTo(0.2);
            await DoneImg.ScaleTo(0.3);
            await DoneImg.ScaleTo(0.4);
            Device.StartTimer(new TimeSpan(0, 0, 3), LaunchMainPage);
        }

        bool LaunchMainPage() {
            App.Current.MainPage.Navigation.PushAsync(new LandingPageView() { BindingContext = new LandingPageViewModel() });
            return false;

        }

        bool OpenPaytm() {
            DependencyService.Get<IAppHandler>().LaunchApp("paytm://");
            return false;
        }

        bool HandleFunc() {
            DisplayAlert("", "FiredImg", "OK");
            return false;
        }

        protected override void OnAppearing() {
            base.OnAppearing();
        }
    }
}
