using System.Collections.Generic;

namespace ScanAndGo.Models {
    public class ProductModel {
        public string title { get; set; }
        public string photoUrl { get; set; }
        public string brand { get; set; }
        public string type { get; set; }
        public List<Variant> variants { get; set; }
        public bool IsSuccess { get; set; }
        public string ScannedBarcode { get; set; }
        public string Price { get; set; }
        public string Quantity { get; set; }
        public string SelectedSize { get; set; }
        public DeliveryType DeliveryType { get; set; } = DeliveryType.TakeAway;
        public float Price
        {
            get;
            set;
        }
        public int Quantity
        {
            get;
            set;
        }
        public string Size
        {
            get;
            set;
        }
    }

    public enum DeliveryType
    {
        TakeAway,
        HomeDelivery
    }
}