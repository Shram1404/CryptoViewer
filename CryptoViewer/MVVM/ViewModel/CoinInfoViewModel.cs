using CryptoViewer.MVVM.Model;
using CryptoViewer.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoViewer.MVVM.ViewModel
{
    class CoinInfoViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public string id = "bitcoin"; // TEMP

        public CoinDataModel? _coin;
        public CoinDataModel? Coin
        {
            get { return _coin; }
            set
            {
                _coin = value;
                OnPropertyChanged(nameof(Coin));
            }
        }

        public CoinInfoViewModel()
        {
            Coin = new CoinDataModel();
        }

        public async Task GetDataFromApi()
        {
            // Отримання даних з API
            var apiData = await CoincapAPI.GetCoinById(id);

            // Перетворення даних з API в об'єкт моделі
            var transformedCoins = DataTransformer.Transform<CoinDataModel>(apiData);

            // Оновити список Coins
            Coin = transformedCoins.FirstOrDefault();
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
