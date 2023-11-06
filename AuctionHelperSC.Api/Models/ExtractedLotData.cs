namespace AuctionHelperSC.Api.Models
{
    public class ExtractedLotData
    {
        public uint Amount { get; set; }
        public uint Price { get; set; } = 1;

        public string Time { get; set; }

        public uint Quality { get; set; }

        public uint PricePerItem {
            get
            {
                if (Amount != 0)
                {
                    return Price / Amount;
                }
                else
                {
                    return 0;
                }
            }
        }
    }
}
