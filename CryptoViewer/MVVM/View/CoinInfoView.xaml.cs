﻿using CryptoViewer.MVVM.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CryptoViewer.MVVM.View
{
    /// <summary>
    /// Логика взаимодействия для CoinInfoView.xaml
    /// </summary>
    public partial class CoinInfoView
    {
        private CoinInfoViewModel _CoinInfoVM;
        public CoinInfoView()
        {
            InitializeComponent();
            Loaded += UserControl_Loaded;
        }
        private async void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            _CoinInfoVM = (CoinInfoViewModel)DataContext;
            await _CoinInfoVM.GetDataFromApi();
        }
    }
}
