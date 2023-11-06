using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;

namespace AuctionHelperSC.Api.Models
{
    public class HistoryLot
    {
        [JsonPropertyName("total")]
        public int Total { get; set; }

        [JsonPropertyName("prices")]
        public List<LotData> lotDatas { get; set; }
    }
}
