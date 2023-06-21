using CryptoViewer.MVVM.Model;
using CryptoViewer.Services;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace CryptoViewer.MVVM.ViewModel
{
    class CoinInfoViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private string _searchText = "bitcoin";

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
            Coins = new ObservableCollection<CoinDataModel>();
        }

        public async Task GetDataFromApi()
        {
            var apiData = await CoincapAPI.GetCoins();
            // Отримання даних з API

            var transformedCoins = DataTransformer.Transform<CoinDataModel>(apiData, true);

            CoinDataModel matchingCoin = transformedCoins.FirstOrDefault(coin => coin.Id.Contains(_searchText));

            Coin = matchingCoin;
        }

        public void SearchCoin(string parameter)
        {
            if (parameter != null)
            {
                _searchText = parameter;
                GetDataFromApi();
            }
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
