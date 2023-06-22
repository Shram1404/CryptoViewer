using CommunityToolkit.Mvvm.ComponentModel;
using CryptoViewer.Core;
using CryptoViewer.MVVM.Model;
using CryptoViewer.Services;
using LiveChartsCore;
using LiveChartsCore.Defaults;
using LiveChartsCore.SkiaSharpView;
using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CryptoViewer.MVVM.ViewModel
{
    [ObservableObject]
    public partial class CoinHistoryLiveViewModel
    {
        private readonly Random _random = new();
        private readonly ObservableCollection<ObservableValue> _observableValues;

        public CoinHistoryLiveViewModel()
        {
            _observableValues = new ObservableCollection<ObservableValue>();

            CoinSeries = new ObservableCollection<ISeries>
            {
                new LineSeries<ObservableValue>
                {
                    Values = _observableValues,
                    Fill = null
                }
            };
        }

        public ObservableCollection<ISeries> CoinSeries { get; set; }

        public ICommand UpdateCommand => new CommunityToolkit.Mvvm.Input.RelayCommand(Update);

        public async Task GetDataFromApi(string id)
        {   
            var apiData = await CoincapAPI.GetCoinHistoryById(id);
            SearchContainer.transformedCoins = DataTransformer.Transform<CoinHistoryModel>(apiData, true);
        }

        public void SearchCoin(string parameter)
        {
            if (parameter != null)
            {
                GetDataFromApi(parameter);
            }
        }

        public void Update()
        {
            if (SearchContainer.transformedCoins != null)
            {
                _observableValues.Clear();
                foreach (var coin in SearchContainer.transformedCoins)
                {
                    double price = double.Parse(coin.PriceUsd, CultureInfo.InvariantCulture);
                    _observableValues.Add(new ObservableValue(price));
                }
            }
        }
    }
}
