using System;
using ScanAndGo.Models;
using ScanAndGo.Services;
using ScanAndGo.Views.Product;
using Xamarin.Forms;

namespace ScanAndGo.ViewModels.Product {
    public class ProductDisplayViewModel : BaseViewModel {
        ProductDisplayPage productPageRef;

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
                ProductModel product = await aPIService.GetProductByID(ID);
                ProductImg = product.photoUrl;
                ProductName = product.name;
                ProductType = product.type;
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
