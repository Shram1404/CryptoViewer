using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace CryptoViewer.API
{
    public static class CoincapAPI
    {
        static readonly string API_URL = "https://api.coincap.io/v2";
        static readonly string API_KEY = ""; // TEMP

        private static readonly HttpClient client = new HttpClient();

        public static void Initialize()
        {
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + API_KEY);
        }   

        public static async Task<string> GetRequest(string Url)
        {
            String? getResponse = await client.GetStringAsync(Url);
            return getResponse.ToString();
        }

        public static async Task<string> GetCryptocurrency() => 
            await GetRequest(String.Format(API_URL + "/assets"));

        public static async Task<string> GetCryptocurrencyById(string id) => 
            await GetRequest(String.Format(API_URL + "/assets/{0}", id));

        public static async Task<string> GetCryptocurrencyHistoryById(string id) => 
            await GetRequest(String.Format(API_URL + "/assets/{0}/history?interval=d1", id));

        public static async Task<string> GetCryptocurrencyPriceById(string id) => 
            await GetRequest(String.Format(API_URL + "/assets/{0}/history?interval=d1", id));

        public static async Task<string> GetCryptocurrencyMarketById(string id) =>
            await GetRequest(String.Format(API_URL + "/assets/{0}/markets", id));

        public static async Task<string> GetCryptocurrencyMarketByIdAndExchange(string id, string exchangeId) =>
            await GetRequest(String.Format(API_URL + "/assets/{0}/markets?exchangeId={1}", id, exchangeId));
    }
}
