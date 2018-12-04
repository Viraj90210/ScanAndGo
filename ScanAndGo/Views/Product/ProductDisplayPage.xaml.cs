using System;
using ScanAndGo.ViewModels.Product;
using Xamarin.Forms;

namespace ScanAndGo.Views.Product {
    public partial class ProductDisplayPage : ContentPage {
        ProductDisplayViewModel productViewModel;
        public ProductDisplayPage() {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            productViewModel = new ProductDisplayViewModel(Navigation, this);
            BindingContext = productViewModel;
            productViewModel.GetProductInfo("z09JQhmQAUzuxhqurSAM");
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

        void IncreaseQuantity(object sender, System.EventArgs e) {
            int value = Convert.ToInt32(lblQuantity.Text);
            if (value == 10) {
                return;
            } else {
                value++;
                lblQuantity.Text = value.ToString();
            }
        }
    }
}