using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using ScanAndGo.Models;
using ScanAndGo.Services;
using ScanAndGo.Services.Payloads;
using ScanAndGo.Views.Pages;
using Xamarin.Essentials;
using Xamarin.Forms;
using static ScanAndGo.Views.Blocks.CartListBlockView;

namespace ScanAndGo.ViewModels.Pages
{
    public class MyCartPageViewModel : BaseViewModel
    {
        public MyCartPageViewModel()
        {
            this.PropertyChanged += Handle_PropertyChanged;
            this.AddressLine1 = "Jda software, Meenakshi tower, 9th floor";
            this.AddressLine2 = "Hyderabad, 500008";
            this.AddAddressCommand = new Command(() => OnNewAddressCommand());
            this.HomeCommand = new Command(() => OnHomeCommand());
            this.PayCommand = new Command(async () => await OnPayCommandAsync());
            PopulateCartList();
        }

        private void PopulateCartList()
        {
            if (App.ProductsInCart != null && App.ProductsInCart.Count > 0)
            {
                Items = new ObservableCollection<object>();
                var deliveryProducts = App.ProductsInCart.Where(p => p.DeliveryType == DeliveryType.HomeDelivery)?.ToList();
                var takeAwayProducts = App.ProductsInCart.Where(p => p.DeliveryType == DeliveryType.TakeAway)?.ToList();
                if (takeAwayProducts != null && takeAwayProducts.Count > 0)
                {
                    var groupModel = new GroupListModel
                    {
                        GroupTitle = "Take away items",
                        GroupImageSource = ImageSource.FromFile("ic_take_away.png"),
                        GroupQuantity = takeAwayProducts.Count
                    };
                    var listItems = new ObservableCollection<ListItem>();
                    foreach (ProductModel product in takeAwayProducts)
                    {
                       var listItem =  new ListItem
                        {
                            Title = product.title,
                            Price = product.Price,
                            Quantity = product.Quantity,
                            Size = product.Size,
                            Model = product
                        };
                        if(!string.IsNullOrEmpty(product.photoUrl))
                        {
                            listItem.ImageSource = ImageSource.FromUri(new Uri(product.photoUrl));
                        }
                        listItems.Add(listItem);
                    }
                    Items.Add(new Grouping<GroupListModel, ListItem>(groupModel, listItems));
                }
                if (deliveryProducts != null && deliveryProducts.Count > 0)
                {
                    var groupModel = new GroupListModel
                    {
                        GroupTitle = "Delivery items",
                        GroupImageSource = ImageSource.FromFile("ic_deliver_items.png"),
                        GroupQuantity = takeAwayProducts.Count
                    };
                    var listItems = new ObservableCollection<ListItem>();
                    foreach (ProductModel product in deliveryProducts)
                    {
                        var listItem = new ListItem
                        {
                            Title = product.title,
                            Price = product.Price,
                            Quantity = product.Quantity,
                            Size = product.Size,
                            ImageSource = ImageSource.FromUri(new Uri(product.photoUrl)),
                            Model = product
                        };
                        listItems.Add(listItem);
                    }
                    Items.Add(new Grouping<GroupListModel, ListItem>(groupModel, listItems));
                }
            }
        }

        private void OnHomeCommand()
        {
            Application.Current.MainPage.Navigation.PopToRootAsync();
        }

        private void OnNewAddressCommand()
        {
            Application.Current.MainPage.DisplayAlert("Add address", "User can add new address here for Delivery items", "OK");
        }

        private async System.Threading.Tasks.Task OnPayCommandAsync()
        {
            //Application.Current.MainPage.DisplayAlert("Payment", "Go to payment page", "OK");
          try
            {
                if( Connectivity.NetworkAccess == NetworkAccess.Internet)
                {
                    APIService aPIService = new APIService();
                    OrderPayload orderPayload = new OrderPayload();
                    // orderPayload.Id = DateTime.UtcNow.Ticks;
                    orderPayload.Id = 1544012550;
                    orderPayload.Total = App.ProductsInCart.Count;
                    orderPayload.Details = new System.Collections.Generic.List<Detail>();
                    foreach (var product in App.ProductsInCart)
                    {
                        Detail detail = new Detail
                        {
                            Barcode = product.ScannedBarcode,
                            Title = product.title,
                            Price = 13499,
                            Quantity = 1,
                            Type = product.DeliveryType == DeliveryType.TakeAway ? "TAKEAWAY" : "DELIVERY",
                            Product = "wLmX1iO821MPZBuf88Qd"
                        };
                        orderPayload.Details.Add(detail);
                    }
                    var result = await aPIService.PostOrder(orderPayload);
                    await Application.Current.MainPage.Navigation.PushAsync(new PaymentBarcodePageView {
                        BindingContext = new PaymentBarcodePageViewModel(orderPayload.Id.ToString()){}

                    });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        void Handle_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if(e.PropertyName.Equals(nameof(SelectedItem)))
            {
                if (SelectedItem == null)
                    return;
                //Do list item selction operation here
                SelectedItem = null;
            }
        }

        public ObservableCollection<object> Items
        {
            get;
            set;
        }

        public object SelectedItem
        {
            get;
            set;
        }

        public string AddressLine1
        {
            get;
            set;
        }

        public string AddressLine2
        {
            get;
            set;
        }

        public ICommand AddAddressCommand
        {
            get;
            set;
        }

        public ICommand HomeCommand
        {
            get;
            set;
        }

        public ICommand PayCommand
        {
            get;
            set;
        }

        public float TotalPrice
        {
            get;
            set;
        }
    }
}

