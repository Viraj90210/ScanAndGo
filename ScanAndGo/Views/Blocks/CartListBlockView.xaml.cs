using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace ScanAndGo.Views.Blocks
{
    public partial class CartListBlockView : ListView
    {
        public CartListBlockView()
        {
            InitializeComponent();
        }


        public class Grouping<K, T> : ObservableCollection<T>
        {
            public K Key { get; private set; }

            public Grouping(K key, IEnumerable<T> items)
            {
                Key = key;
                foreach (var item in items)
                    this.Items.Add(item);
            }
        }
        public class GroupListModel : BindableObject
        {
            public string GroupTitle
            {
                get;
                set;
            }

            public int GroupQuantity
            {
                get;
                set;
            }

            public ImageSource GroupImageSource { get; set; } = ImageSource.FromFile("ShoppingCart.png");
           
        }
        public class ListItem : BindableObject
        {
            public string Title
            {
                get;
                set;
            }

            public string Size
            {
                get;
                set;
            }

            public float Price
            {
                get;
                set;
            }

            public ImageSource ImageSource
            {
                get;
                set;
            }

            public int Quantity
            {
                get;
                set;
            }

            public object Model
            {
                get;
                set;
            }
        }
    }
}
