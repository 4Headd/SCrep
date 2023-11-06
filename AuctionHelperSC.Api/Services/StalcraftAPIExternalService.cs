using AuctionHelperSC.Api.ServiceInterfaces;
using System.Text.Json;
using AuctionHelperSC.Api.Models;
using System.Text.Json.Serialization;
using System.Net.Http.Json;
using Newtonsoft.Json;

namespace AuctionHelperSC.Api.Services
{
    public class StalcraftAPIExternalService : IStalcraftAPIExternalService
    {

        public async Task<string> GetItemPriceHistory(string itemId)
        {
            string responseString = "";


            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("Client-Id", "279");
                httpClient.DefaultRequestHeaders.Add("Client-Secret", "DeTPCkMdXMeeudRiJZxQSMhBPiHyEnUnnYPRJhwv");
                string requestUrl = @"https://eapi.stalcraft.net/ru/auction/" + itemId + "/history?additional=true&limit=100";
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, new Uri(requestUrl));
               
                HttpResponseMessage response = httpClient.Send(request);

                responseString = await response.Content.ReadAsStringAsync();
            }
            //var deserializedResponse = JsonConvert.DeserializeObject<HistoryLot>(responseString);

            //var extractedDataList = new List<HistoryLot>

            /* List<ExtractedLotData> result = deserializedResponse.lotDatas.Select(item => new ExtractedLotData
             {
                 Amount = item.Amount,
                 Price = item.Price,
                 Time = item.Time,
                 additionalInfo = item.additionalInfo

             }).ToList();*/


            //string resultJson = JsonConvert.SerializeObject(result);
            //return deserializedResponse;

            List<ExtractedLotData> result = new List<ExtractedLotData>();

            using (JsonDocument document = JsonDocument.Parse(responseString))
            {
                if (document.RootElement.TryGetProperty("prices", out JsonElement prices))
                {
                    foreach (JsonElement price in prices.EnumerateArray())
                    {
                        if (price.TryGetProperty("additional", out JsonElement additional))
                        {
                            if (additional.TryGetProperty("qlt", out JsonElement quality))
                            {
                                result.Add(new ExtractedLotData
                                {
                                    Amount = price.GetProperty("amount").GetUInt32(),
                                    Price = price.GetProperty("price").GetUInt32(),
                                    Time = price.GetProperty("time").GetString(),
                                    Quality = quality.GetUInt32()
                                });
                            }
                            else
                            {
                                result.Add(new ExtractedLotData
                                {
                                    Amount = price.GetProperty("amount").GetUInt32(),
                                    Price = price.GetProperty("price").GetUInt32(),
                                    Time = price.GetProperty("time").GetString()
                                });
                            }
                        }
                    }
                }
            }

            Dictionary<string, List<ExtractedLotData>> resultDictionary = new Dictionary<string, List<ExtractedLotData>>();

            resultDictionary["result"] = result;

            string resultJson = JsonConvert.SerializeObject(resultDictionary);
            return resultJson;
        }
    }
}
