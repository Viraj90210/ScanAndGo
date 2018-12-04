using Newtonsoft.Json;

namespace ScanAndGo.Models {
    public class Size {
        [JsonProperty(PropertyName = "quantity")]
        public int Quantity { get; set; }
        [JsonProperty(PropertyName = "size")]
        public string SizeName { get; set; }
    }
}