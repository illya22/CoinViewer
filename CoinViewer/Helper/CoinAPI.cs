using CoinViewer.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CoinViewer.Helper
{
    public class CoinAPI
    {
        private const string ApiBaseUrl = "https://api.coincap.io/v2/";

        public async Task<List<string>> GetAllCoinNames()
        {
            using (HttpClient httpClient = new HttpClient())
            {
                string apiUrl = $"{ApiBaseUrl}assets";

                try
                {
                    HttpResponseMessage response = await httpClient.GetAsync(apiUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        string responseData = await response.Content.ReadAsStringAsync();


                        JObject jsonObject = JsonConvert.DeserializeObject<JObject>(responseData);
                        JArray coinsArray = jsonObject["data"] as JArray;

                        if (coinsArray != null)
                        {
                            List<string> coinNames = coinsArray.Select(coin => coin["name"].ToString()).ToList();
                            return coinNames;
                        }
                    }
                    else
                    {

                        Console.WriteLine($"Error: {response.StatusCode}");
                    }
                }
                catch (Exception ex)
                {

                    Console.WriteLine($"Exception: {ex.Message}");
                }

                return null;
            }
        }

        public async Task<List<Currency>> GetAllCurrencies()
        {
            using (HttpClient httpClient = new HttpClient())
            {
                string apiUrl = "https://api.coincap.io/v2/assets";

                try
                {
                    HttpResponseMessage response = await httpClient.GetAsync(apiUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        string responseData = await response.Content.ReadAsStringAsync();
                        JObject jsonObject = JsonConvert.DeserializeObject<JObject>(responseData);

                        if (jsonObject != null)
                        {
                            JArray currenciesArray = jsonObject["data"] as JArray;

                            if (currenciesArray != null)
                            {
                                List<Currency> currencies = currenciesArray.Select(currency => new Currency
                                {
                                    Id = currency["id"].ToString(),
                                    Name = currency["name"].ToString(),
                                    Symbol = currency["symbol"].ToString(),
                                    Price = Convert.ToDecimal(currency["priceUsd"]),
                                    Rank = Convert.ToInt32(currency["rank"]),
                                    Supply = Convert.ToDecimal(currency["supply"]),

                                    MarketCapUsd = Convert.ToDecimal(currency["marketCapUsd"]),
                                    VolumeUsd24Hr = Convert.ToDecimal(currency["volumeUsd24Hr"]),
                                    ChangePercent24Hr = Convert.ToDecimal(currency["changePercent24Hr"]),
                                    Vwap24Hr = Convert.ToDecimal(currency["vwap24Hr"]),
                                }).ToList();

                                return currencies;
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Error: {response.StatusCode}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Exception: {ex.Message}");
                }

                return null;
            }
        }
    }
}
