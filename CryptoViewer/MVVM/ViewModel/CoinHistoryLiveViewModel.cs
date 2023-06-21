using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CryptoViewer.Core;
using LiveChartsCore;
using LiveChartsCore.Defaults;
using LiveChartsCore.SkiaSharpView;
using CommunityToolkit.Mvvm.Input;

namespace CryptoViewer.MVVM.ViewModel
{
    [ObservableObject]
    public partial class CoinHistoryLiveViewModel
    {
        private readonly Random _random = new();
        private readonly ObservableCollection<ObservableValue> _observableValues;

        public CoinHistoryLiveViewModel()
        {
            // Use ObservableCollections to let the chart listen for changes (or any INotifyCollectionChanged). 
            _observableValues = new ObservableCollection<ObservableValue>
        {
            // Use the ObservableValue or ObservablePoint types to let the chart listen for property changes 
            // or use any INotifyPropertyChanged implementation 
            new ObservableValue(2),
            new(5), // the ObservableValue type is redundant and inferred by the compiler (C# 9 and above)
            new(4),
            new(5),
            new(2),
            new(6),
            new(6),
            new(6),
            new(4),
            new(2),
            new(3),
            new(4),
            new(3)
        };

            Series = new ObservableCollection<ISeries>
        {
            new LineSeries<ObservableValue>
            {
                Values = _observableValues,
                Fill = null
            }
        };

            // in the following sample notice that the type int does not implement INotifyPropertyChanged
            // and our Series.Values property is of type List<T>
            // List<T> does not implement INotifyCollectionChanged
            // this means the following series is not listening for changes.
            // Series.Add(new ColumnSeries<int> { Values = new List<int> { 2, 4, 6, 1, 7, -2 } }); 
        }

        public ObservableCollection<ISeries> Series { get; set; }

            public ICommand AddItemCommand => new CommunityToolkit.Mvvm.Input.RelayCommand(AddItem);
            public ICommand RemoveItemCommand => new CommunityToolkit.Mvvm.Input.RelayCommand(RemoveItem, () => _observableValues.Count > 0);
            public ICommand UpdateItemCommand => new CommunityToolkit.Mvvm.Input.RelayCommand(UpdateItem);
            public ICommand ReplaceItemCommand => new CommunityToolkit.Mvvm.Input.RelayCommand(ReplaceItem);
            public ICommand AddSeriesCommand => new CommunityToolkit.Mvvm.Input.RelayCommand(AddSeries, () => Series.Count < 5);
            public ICommand RemoveSeriesCommand => new CommunityToolkit.Mvvm.Input.RelayCommand(RemoveSeries, () => Series.Count > 1);

        
            public void AddItem()
            {
                var randomValue = _random.Next(1, 10);
                _observableValues.Add(new(randomValue));
            }

            public void RemoveItem()
            {
                if (_observableValues.Count == 0) return;
                _observableValues.RemoveAt(0);
            }

            public void UpdateItem()
            {
                var randomValue = _random.Next(1, 10);

                // we grab the last instance in our collection
                var lastInstance = _observableValues[_observableValues.Count - 1];

                // finally modify the value property and the chart is updated!
                lastInstance.Value = randomValue;
            }

            public void ReplaceItem()
            {
                var randomValue = _random.Next(1, 10);
                var randomIndex = _random.Next(0, _observableValues.Count - 1);
                _observableValues[randomIndex] = new(randomValue);
            }

            public void AddSeries()
            {
                //  for this sample only 5 series are supported.
                if (Series.Count == 5) return;

                Series.Add(
                    new LineSeries<int>
                    {
                        Values = new List<int>
                        {
                            _random.Next(0, 10),
                            _random.Next(0, 10),
                            _random.Next(0, 10)
                        }
                    });
            }

            public void RemoveSeries()
            {
                if (Series.Count == 1) return;

                Series.RemoveAt(Series.Count - 1);
            }
    }
}
