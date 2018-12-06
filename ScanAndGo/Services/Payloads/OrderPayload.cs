using System;
using System.Collections.Generic;

using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace ScanAndGo.Services.Payloads
{
    public class OrderPayload
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("total")]
        public long Total { get; set; }

        [JsonProperty("details")]
        public List<Detail> Details { get; set; }
    }

    public class Detail
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("price")]
        public float Price { get; set; }

        [JsonProperty("quantity")]
        public long Quantity { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("barcode")]
        public string Barcode { get; set; }

        [JsonProperty("product")]
        public string Product { get; set; }
    }
}

