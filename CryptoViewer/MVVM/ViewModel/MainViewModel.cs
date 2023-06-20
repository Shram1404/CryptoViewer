using CryptoViewer.Core;

namespace CryptoViewer.MVVM.ViewModel
{
    class MainViewModel : ObservableObject
    {
        public RelayCommand HomeViewCommand { get; set; }
        public RelayCommand CoinInfoViewCommand { get; set; }

        public HomeViewModel HomeVM { get; set; }
        public CoinInfoViewModel CoinInfoVM { get; set; }

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
        public MainViewModel()
        {
            HomeVM = new HomeViewModel();
            CoinInfoVM = new CoinInfoViewModel();

            CurrentView = HomeVM;

            HomeViewCommand = new RelayCommand(o =>
            {
                CurrentView = HomeVM;
            });

            CoinInfoViewCommand = new RelayCommand(o =>
            {
                CurrentView = CoinInfoVM;
            });
        }
    }
}
