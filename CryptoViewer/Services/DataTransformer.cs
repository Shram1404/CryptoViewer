using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text.Json;

namespace CryptoViewer.Services
{
    static class DataTransformer
    {
        public static ObservableCollection<T> Transform<T>(string apiData, bool isArray = false)
        {
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            using var jsonDocument = JsonDocument.Parse(apiData);
            var data = jsonDocument.RootElement.GetProperty("data").GetRawText();



            if (isArray)
            {
                T[] models = null;
                try
                {
                    models = JsonSerializer.Deserialize<T[]>(data, options);
                }
                catch (Exception ex)
                {
                    Trace.WriteLine("Transform exception");
                }

                var collection = new ObservableCollection<T>(models ?? Array.Empty<T>());
                return collection;
            }
            else
            {
                var model = JsonSerializer.Deserialize<T>(data, options);
                var collection = new ObservableCollection<T>();
                collection.Add(model);
                return collection;
            }
        }
    }
}
