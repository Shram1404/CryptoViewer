using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using CryptoViewer.MVVM.ViewModel;

namespace CryptoViewer.MVVM.View
{
    public partial class HomeView : UserControl
    {
        private HomeViewModel _homeVM;
        private DispatcherTimer _timer;

        private bool AutoRefresh = false;

        public HomeView()
        {
            InitializeComponent();
            Loaded += UserControl_Loaded;

            _timer = new DispatcherTimer();
            _timer.Interval = TimeSpan.FromSeconds(5); // Оновлення кожні 5 секунд
            _timer.Tick += Timer_Tick;
        }

        private async void Timer_Tick(object sender, EventArgs e)
        {
            if (AutoRefresh)
                await _homeVM.GetDataFromApi();
        }

        private async void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            _homeVM = (HomeViewModel)DataContext;
            await _homeVM.GetDataFromApi();

            _timer.Start();
        }

        private void ToggleButton_Checked(object sender, RoutedEventArgs e)
        {
            AutoRefresh = true;
            _timer.Start();
        }

        private void ToggleButton_Unchecked(object sender, RoutedEventArgs e)
        {
            AutoRefresh = false;
            _timer.Stop();
        }

    }
}
