using System.Text.Json.Serialization;

namespace AuctionHelperSC.Api.Models
{
    public class AdditionalInfo
    {
        [JsonPropertyName("upgrade_bonus")]
        public string? UpgradeBonus { get; set; }

        [JsonPropertyName("it_transf_count")]
        public uint? TransferCount { get; set; }

        [JsonPropertyName("qlt")]
        public uint? Quality { get; set; }

        [JsonPropertyName("spawn_time")]
        public string? SpawnTime { get; set; }


        [JsonPropertyName("stats_random")]
        public double? StatsRandom { get; set; }

        [JsonPropertyName("m_dk")]
        public double?  MaxHealthDischarged{ get; set; }

        [JsonPropertyName("ndmg")]
        public double? CurrentHealthDischarged { get; set; }

        [JsonPropertyName("ptn")]
        public int? Level { get; set; }
    }
}
