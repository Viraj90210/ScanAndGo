using ScanAndGo.ViewModels.Cart;
using Xamarin.Forms;

namespace ScanAndGo.Views.Cart {
    public partial class CartPage : ContentPage {
        CartPageViewModel cartPageViewModel;
        public CartPage() {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            cartPageViewModel = new CartPageViewModel(Navigation, this);
            BindingContext = cartPageViewModel;

        }
    }
}
