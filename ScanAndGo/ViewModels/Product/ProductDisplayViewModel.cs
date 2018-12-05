using System;
using System.Collections.Generic;
using System.Windows.Input;
using System.Threading.Tasks;
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

        Command ClickBackCommand;
        public Command ClickBack {
            get {
                return ClickBackCommand ?? (ClickBackCommand = new Command(ExecuteBack));
            }
        }

        void ExecuteBack() {
            navigationRef.PopAsync();
        }

        internal void LoadSizeButtons(List<Variant> sizes) {
            List<View> buttons = new List<View>();
            foreach (var sizeBtn in product.variants) {
                var btn = new Button {
                    Text = sizeBtn.title,
                    TextColor = Color.White,
                    VerticalOptions = LayoutOptions.Center,
                    HorizontalOptions = LayoutOptions.Start,
                    WidthRequest = 70
                };
                if (product.ScannedBarcode.Equals(sizeBtn.barcode)) {
                    btn.BackgroundColor = (Color)Application.Current.Resources["FadedBlue"];
                } else {
                    btn.BackgroundColor = (Color)Application.Current.Resources["LightGray"];
                }
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
            AddToCartCommand = new Command(() =>
            {

            });
        }

        internal async Task GetProductInfo(string ID) {
            try {
                APIService aPIService = new APIService();
                product = await aPIService.GetProductByID(ID);
                if (product.IsSuccess) {
                    ProductImg = product.photoUrl;
                    ProductName = product.title;
                    ProductType = product.type;
                    LoadSizeButtons(product.variants);
                } else {
                    await productPageRef.DisplayAlert("", "There was a problem, please try again", "OK");
                }
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
        }

        public ICommand AddToCartCommand
        {
            get;
            set;
        }
    }
}
