using CryptoViewer.Core;

namespace CryptoViewer.MVVM.ViewModel
{
    class MainViewModel : ObservableObject
    {
        public RelayCommand HomeViewCommand { get; set; }
        public RelayCommand CoinInfoViewCommand { get; set; }
        public RelayCommand CoinHistoryLiveViewCommand { get; set; }

        public RelayCommand SearchCommand { get; set; }

        public HomeViewModel HomeVM { get; set; }
        public CoinInfoViewModel CoinInfoVM { get; set; }
        public CoinHistoryLiveViewModel CoinHistoryLiveVM { get; set; }

        private static string _searchText;

        public string SearchText
        {
            get { return _searchText; }
            set
            {
                _searchText = value;
                OnPropertyChanged();
            }
        }

        private object _currentView;

        public object CurrentView
        {
            get { return _currentView; }
            set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }

        private CoinHistoryLiveViewModel _coinHistoryLiveVM;

        public MainViewModel()
        {
            HomeVM = new HomeViewModel();
            CoinInfoVM = new CoinInfoViewModel();
            _coinHistoryLiveVM = new CoinHistoryLiveViewModel();
            CurrentView = HomeVM;

            HomeViewCommand = new RelayCommand(o =>
            {
                CurrentView = HomeVM;
            });

            CoinInfoViewCommand = new RelayCommand(o =>
            {
                CurrentView = CoinInfoVM;
            });

            CoinHistoryLiveViewCommand = new RelayCommand(o =>
            {
                CurrentView = _coinHistoryLiveVM;
            });

            SearchCommand = new RelayCommand(o =>
            {
                if (CurrentView == CoinInfoVM)
                    CoinInfoVM.SearchCoin(SearchText);
                if (CurrentView == _coinHistoryLiveVM)
                    _coinHistoryLiveVM.SearchCoin(SearchText);
            });
        }
    }
}
