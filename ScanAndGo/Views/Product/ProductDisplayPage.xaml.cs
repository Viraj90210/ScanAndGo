using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using ScanAndGo.Models;
using ScanAndGo.ViewModels.Product;
using Xamarin.Forms;

namespace ScanAndGo.Views.Product {
    public partial class ProductDisplayPage : ContentPage {

        ProductDisplayViewModel productViewModel;


        public ProductDisplayPage(string barcodeValue) {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            Title = "Product";
            if (Device.RuntimePlatform == Device.iOS) {
                Icon = "ProductIcon.png";
            }
            productViewModel = new ProductDisplayViewModel(Navigation, this);
            BindingContext = productViewModel;
            productViewModel.GetProductInfo(barcodeValue);
        }

        void DecreaseQuantity(object sender, System.EventArgs e) {
            int value = Convert.ToInt32(lblQuantity.Text);
            if (value == 1) {
                return;
            } else {
                value--;
                lblQuantity.Text = value.ToString();
            }
        }

        public void AddButtonsToScroll(ICollection<View> data) {
            foreach (var btn in data) {
                ButtonBar.Children.Add(btn);
            }
        }

        //public void SizeSelected(object sender, System.EventArgs w) {
        //    var btn = (Button)sender;
        //    ResetBtnColors();
        //    btn.BackgroundColor = (Color)Application.Current.Resources["FadedBlue"];
        //    btn.TextColor = Color.White;
        //}

        public void ResetBtnColors() {
            foreach (View i in ((StackLayout)ButtonBar).Children.Where(x => x.GetType() == typeof(Button))) {
                i.BackgroundColor = (Color)Application.Current.Resources["LightGray"];
            }
        }

        void Handle_TappedTA(object sender, System.EventArgs e) {
            DeliveryRadio.Source = "RadioUncheck.png";
            TakeAwayRadio.Source = "RadioCheck.png";
            lblTakeAway.TextColor = (Color)Application.Current.Resources["FadedBlue"];
            lblDelivery.TextColor = Color.Black;
            ShakeAnimation();
            if(this.BindingContext is ProductDisplayViewModel)
            {
                (this.BindingContext as ProductDisplayViewModel).product.DeliveryType = DeliveryType.TakeAway;
            }

        }

        void Handle_TappedDL(object sender, System.EventArgs e) {
            if (this.BindingContext is ProductDisplayViewModel)
            {
                (this.BindingContext as ProductDisplayViewModel).product.DeliveryType = DeliveryType.HomeDelivery;
            }
            TakeAwayRadio.Source = "RadioUncheck.png";
            DeliveryRadio.Source = "RadioCheck.png";
            lblTakeAway.TextColor = Color.Black;
            lblDelivery.TextColor = (Color)Application.Current.Resources["FadedBlue"];
            ShakeAnimation();
        }

        async void ShakeAnimation() {
            await btnAddToCart.RotateTo(5, 50);
            await btnAddToCart.RotateTo(-5, 50);
            await btnAddToCart.RotateTo(5, 50);
            await btnAddToCart.RotateTo(-5, 50);
            await btnAddToCart.RotateTo(5, 50);
            await btnAddToCart.RotateTo(-5, 50);
            await btnAddToCart.RotateTo(5, 50);
            await btnAddToCart.RotateTo(-5, 50);
            await btnAddToCart.RotateTo(5, 50);
            await btnAddToCart.RotateTo(-5, 50);
            await btnAddToCart.RotateTo(0, 50);
        }

        void IncreaseQuantity(object sender, System.EventArgs e) {
            int value = Convert.ToInt32(lblQuantity.Text);
            if (value == 10) {
                return;
            } else {
                value++;
                lblQuantity.Text = value.ToString();
            }
        }

        void AddItemToCart(object sender, System.EventArgs e) {

        }

    }
}