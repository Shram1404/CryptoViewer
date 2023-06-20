using CryptoViewer.MVVM.Model;
using CryptoViewer.Services;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace CryptoViewer.MVVM.ViewModel
{
    class HomeViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<CoinDataModel> _coins;
        public ObservableCollection<CoinDataModel> Coins
        {
            get { return _coins; }
            set
            {
                _coins = value;
                OnPropertyChanged(nameof(Coins));
            }
        }

        public HomeViewModel()
        {
            Coins = new ObservableCollection<CoinDataModel>();
        }

        public async Task GetDataFromApi()
        {
            // Отримання даних з API
            var apiData = await CoincapAPI.GetCoins();

            // Перетворення даних з API в об'єкти моделі та обмеження до перших 10 монет
            var transformedCoins = DataTransformer.Transform<CoinDataModel>(apiData, true).Take(10);

            // Оновити список Coins
            Coins.Clear();
            foreach (var coin in transformedCoins)
            {
                coin.PriceUsd = decimal.Round(decimal.Parse(coin.PriceUsd, CultureInfo.InvariantCulture), 4).ToString("0.0000");
                Coins.Add(coin);
            }
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}
