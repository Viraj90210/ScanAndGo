using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;
using static ScanAndGo.Views.Blocks.CartListBlockView;

namespace ScanAndGo.ViewModels.Pages
{
    public class MyCartPageViewModel : BaseViewModel
    {
        public MyCartPageViewModel()
        {
            this.PropertyChanged += Handle_PropertyChanged;
            this.AddressLine1 = "Chinchpokli bandar khaugali, haveri";
            this.AddressLine2 = "Hyderabad, 500008";
            this.AddAddressCommand = new Command(() => OnNewAddressCommand());
            this.HomeCommand = new Command(() => OnHomeCommand());
            Items = new ObservableCollection<object>()
            {
                new Grouping<GroupListModel,ListItem>(new GroupListModel{
                    GroupTitle = "Take away items",
                    GroupImageSource = ImageSource.FromFile("ShoppingCart.png"),
                    GroupQuantity=2},new ObservableCollection<ListItem>{
                    new ListItem{
                        Title = "Woodland shoes from england with extra",
                        Price = 199.0f,
                        Quantity = 1,
                        Size = "7 UK",
                        ImageSource = ImageSource.FromFile("payment.png")
                    },
                    new ListItem{
                        Title = "Roadstart shirt Maroon",
                        Price = 23,
                        Size = "M/40",
                        Quantity = 2,
                        ImageSource = ImageSource.FromFile("payment.png")
                    }
                }),
                new Grouping<GroupListModel,ListItem>(new GroupListModel{
                    GroupTitle = "Take away items",
                    GroupImageSource = ImageSource.FromFile("ShoppingCart.png"),
                    GroupQuantity=1},new ObservableCollection<ListItem>{
                    new ListItem{
                        Title = "Spyker Jeans Black shadow",
                        Price = 102311,
                        Size = "32",
                         Quantity = 5,
                        ImageSource = ImageSource.FromFile("payment.png")
                    }
                })
            };
        }

        private void OnHomeCommand()
        {
            Application.Current.MainPage.Navigation.PopToRootAsync();
        }

        private void OnNewAddressCommand()
        {
            Application.Current.MainPage.DisplayAlert("Add address", "User can add new address here for Delivery items", "OK");
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
    }
}

