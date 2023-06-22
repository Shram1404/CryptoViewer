using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CryptoViewer.MVVM.Model
{
    class CoinHistoryModel
    {
        [JsonPropertyName("priceUsd")]
        public string PriceUsd { get; set; }

        [JsonPropertyName("time")]
        public long Time { get; set; }

        [JsonPropertyName("date")]
        public string Date { get; set; }
    }
}
