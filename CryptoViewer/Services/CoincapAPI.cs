using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CryptoViewer.Services
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

        private static async Task<string> GetRequest(string Url)
        {
            Thread.Sleep(30); // TEMP
            string? getResponse = await client.GetStringAsync(Url);
            return getResponse.ToString();
        }

        public static async Task<string> GetCoins() =>
            await GetRequest(string.Format(API_URL + "/assets"));

        public static async Task<string> GetCoinById(string id) =>
            await GetRequest(string.Format(API_URL + "/assets/{0}", id));

        public static async Task<string> GetCoinHistoryById(string id) =>
            await GetRequest(string.Format(API_URL + "/assets/{0}/history?interval=d1", id));

        public static async Task<string> GetCoinPriceById(string id) =>
            await GetRequest(string.Format(API_URL + "/assets/{0}/history?interval=d1", id));

        public static async Task<string> GetCoinMarketById(string id) =>
            await GetRequest(string.Format(API_URL + "/assets/{0}/markets", id));

        public static async Task<string> GetCoinMarketByIdAndExchange(string id, string exchangeId) =>
            await GetRequest(string.Format(API_URL + "/assets/{0}/markets?exchangeId={1}", id, exchangeId));
    }
}
