using System;
using ScanAndGo.Views.Cart;
using Xamarin.Forms;

namespace ScanAndGo.ViewModels.Cart {
    public class CartPageViewModel : BaseViewModel {
        CartPage cartPageRef;
        public CartPageViewModel(INavigation navigation, CartPage cartPage) {
            navigationRef = navigation;
            cartPageRef = cartPage;
        }
    }
}
