using ScanAndGo.ViewModels.Cart;
using Xamarin.Forms;

namespace ScanAndGo.Views.Cart {
    public partial class CartPage : ContentPage {
        CartPageViewModel cartPageViewModel;
        public CartPage() {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            Title = "Cart";
            if (Device.RuntimePlatform == Device.iOS) {
                Icon = "CartIcon.png";
            }
            cartPageViewModel = new CartPageViewModel(Navigation, this);
            BindingContext = cartPageViewModel;
        }
    }
}
