using System;
using Xamarin.Forms;

namespace ScanAndGo.Models {
    public class ProductModel {
        public string color { get; set; }
        public string brand { get; set; }
        public bool discount { get; set; }
        public int mrp { get; set; }
        public string photoUrl { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public int price { get; set; }
        public Size size { get; set; }
    }
}