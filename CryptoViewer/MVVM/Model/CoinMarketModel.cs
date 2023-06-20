﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoViewer.MVVM.Model
{
    class CoinMarketModel
    {
        public string ExchangeId { get; set; }
        public string Rank { get; set; }
        public string BaseSymbol { get; set; }
        public string BaseId { get; set; }
        public string QuoteSymbol { get; set; }
        public string QuoteId { get; set; }
        public string PriceQuote { get; set; }
        public string PriceUsd { get; set; }
        public string VolumeUsd24Hr { get; set; }
        public string PercentExchangeVolume { get; set; }
        public string TradesCount24Hr { get; set; }
        public string Updated { get; set; }
    }
}
