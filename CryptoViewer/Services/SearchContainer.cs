using CryptoViewer.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoViewer.Services
{
    static class SearchContainer
    {
        public static ObservableCollection<CoinHistoryModel> transformedCoins { get; set; }
    }
}
