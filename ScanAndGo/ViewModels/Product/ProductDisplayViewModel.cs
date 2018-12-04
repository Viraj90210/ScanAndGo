using System;
using System.Collections.Generic;
using ScanAndGo.Models;
using ScanAndGo.Services;
using ScanAndGo.Views.Product;
using Xamarin.Forms;

namespace ScanAndGo.ViewModels.Product {
    public class ProductDisplayViewModel : BaseViewModel {
        ProductDisplayPage productPageRef;
        ProductModel product;
        string _productImg;
        public string ProductImg {
            get { return _productImg; }
            set { SetProperty(ref _productImg, value, "ProductImg"); }
        }

        string _productName;
        public string ProductName {
            get { return _productName; }
            set { SetProperty(ref _productName, value, "ProductName"); }
        }

        internal void LoadSizeButtons(List<Models.Size> sizes) {
            List<View> buttons = new List<View>();
            foreach (var sizeBtn in product.sizes) {
                var btn = new Button {
                    Text = sizeBtn.SizeName,
                    TextColor = Color.White,
                    BackgroundColor = (Color)Application.Current.Resources["LightGray"],
                    VerticalOptions = LayoutOptions.Center,
                    HorizontalOptions = LayoutOptions.Start,
                    WidthRequest = 70
                };
                btn.Clicked += Btn_Clicked;
                buttons.Add(btn);
            }
            productPageRef.AddButtonsToScroll(buttons);
        }

        void Btn_Clicked(object sender, EventArgs e) {
            var btn = (Button)sender;
            productPageRef.ResetBtnColors();
            btn.BackgroundColor = (Color)Application.Current.Resources["FadedBlue"];
            btn.TextColor = Color.White;
        }

        string _productType;
        public string ProductType {
            get { return _productType; }
            set { SetProperty(ref _productType, value, "ProductType"); }
        }


        public ProductDisplayViewModel(INavigation navigation, ProductDisplayPage productPage) {
            productPageRef = productPage;
            navigationRef = navigation;
        }

        internal async void GetProductInfo(string ID) {
            try {
                APIService aPIService = new APIService();
                product = await aPIService.GetProductByID(ID);
                ProductImg = product.photoUrl;
                ProductName = product.name;
                ProductType = product.type;
                LoadSizeButtons(product.sizes);
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
