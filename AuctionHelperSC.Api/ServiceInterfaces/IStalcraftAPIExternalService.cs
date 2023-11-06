using AuctionHelperSC.Api.Models;

namespace AuctionHelperSC.Api.ServiceInterfaces
{
    public interface IStalcraftAPIExternalService
    {
        public Task<string> GetItemPriceHistory(string itemId);
    }
}
