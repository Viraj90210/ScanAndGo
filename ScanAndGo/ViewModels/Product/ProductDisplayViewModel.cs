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

        string _productFinalPrice;
        public string ProductFinalPrice {
            get { return _productFinalPrice; }
            set { SetProperty(ref _productFinalPrice, "Rs: " + value + "/- ", "ProductFinalPrice"); }
        }

        string _productDiscount;
        public string ProductDiscountPrice {
            get { return _productDiscount; }
            set { SetProperty(ref _productDiscount, value, "ProductDiscountPrice"); }
        }

        string _productMRP;
        public string ProductMRP {
            get { return _productMRP; }
            set { SetProperty(ref _productMRP, value, "ProductMRP"); }
        }

        TextDecorations _textDeco = TextDecorations.None;
        public TextDecorations TextDeco {
            get { return _textDeco; }
            set { SetProperty(ref _textDeco, value, "TextDeco"); }
        }

        private int IntQuatity = 1;

        string _Quantity = "1";
        public string Quantity {
            get { return _Quantity; }
            set { SetProperty(ref _Quantity, value, "Quantity"); }
        }

        Command DecreaseQuantityCommand;
        public Command DecreaseQuantity {
            get {
                return DecreaseQuantityCommand ?? (DecreaseQuantityCommand = new Command(ExecuteDecreaseQuantity));
            }
        }

        Command IncreaseQuantityCommand;
        public Command IncreaseQuantity {
            get {
                return IncreaseQuantityCommand ?? (IncreaseQuantityCommand = new Command(ExecuteIncreaseQuantity));
            }
        }

        void ExecuteDecreaseQuantity(object obj) {
            if (IntQuatity == 1) {
                return;
            } else {
                IntQuatity--;
                Quantity = IntQuatity.ToString();
                product.Quantity = Quantity;
            }
        }

        void ExecuteIncreaseQuantity(object obj) {
            if (IntQuatity == 10) {
                return;
            } else {
                IntQuatity++;
                Quantity = IntQuatity.ToString();
                product.Quantity = Quantity;
            }
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
                    if (sizeBtn.discount_amount == null) {
                        ProductFinalPrice = sizeBtn.net_price.ToString();
                        product.Price = ProductFinalPrice;
                    } else {
                        ProductFinalPrice = sizeBtn.net_price.ToString();
                        if (sizeBtn.discount_amount > 0) {
                            ProductMRP = "MRP: " + sizeBtn.price.ToString();
                            ProductDiscountPrice = "Discount: " + sizeBtn.discount_amount.ToString();
                            TextDeco = TextDecorations.Strikethrough;
                        } else {
                            ProductMRP = "";
                            ProductDiscountPrice = "";
                        }
                    }
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
            foreach (var button in product.variants) {
                if (button.title.Equals(btn.Text)) {
                    if (button.discount_amount == null) {
                        ProductFinalPrice = button.net_price.ToString();
                        product.Price = ProductFinalPrice;
                    } else {
                        ProductFinalPrice = button.net_price.ToString();
                        if (button.discount_amount > 0) {
                            ProductMRP = "MRP: " + button.price.ToString() + "/-";
                            ProductDiscountPrice = "Discount: " + button.discount_amount.ToString();
                            TextDeco = TextDecorations.Strikethrough;
                        } else {
                            ProductMRP = "";
                            ProductDiscountPrice = "";
                        }
                    }
                }
            }
        }

        string _productType;
        public string ProductType {
            get { return _productType; }
            set { SetProperty(ref _productType, value, "ProductType"); }
        }

        public ProductDisplayViewModel(INavigation navigation, ProductDisplayPage productPage) {
            productPageRef = productPage;
            navigationRef = navigation;
            AddToCartCommand = new Command(() => {

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

        public ICommand AddToCartCommand {
            get;
            set;
        }
    }
}
