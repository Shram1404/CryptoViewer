using System.Collections.ObjectModel;
using System.Text.Json;
using CryptoViewer.MVVM.Model;

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
                var models = JsonSerializer.Deserialize<T[]>(data, options);
                var collection = new ObservableCollection<T>(models ?? System.Array.Empty<T>());
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
