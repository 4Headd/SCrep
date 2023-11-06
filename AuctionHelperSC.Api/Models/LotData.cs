using System.Text.Json.Serialization;

namespace AuctionHelperSC.Api.Models
{
    public class LotData
    {
        [JsonPropertyName("amount")]
        public uint Amount { get; set; }


        [JsonPropertyName("price")]
        public uint Price { get; set; }

        [JsonPropertyName("time")]
        public string Time { get; set; }

        [JsonPropertyName("additional")]
        public AdditionalInfo additionalInfo { get; set; }
    }
}
