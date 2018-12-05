using System;
namespace ScanAndGo.Models {
    public class Variant {
        public int discount_amount { get; set; }
        public int position { get; set; }
        public int price { get; set; }
        public string title { get; set; }
        public string barcode { get; set; }
        public string product { get; set; }
    }
}
