using AuctionHelperSC.Api.Models;
using AuctionHelperSC.Api.ServiceInterfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AuctionHelperSC.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuctionController : ControllerBase
    {
        private readonly IStalcraftAPIExternalService stalcraftAPIExternal;

        public AuctionController(IStalcraftAPIExternalService stalcraftAPIExternal)
        {
            this.stalcraftAPIExternal = stalcraftAPIExternal;
        }

        [HttpGet]
        [Route("ItemHistory/{itemId}")]
        public async Task<string> GetAuctionHistory(string itemId)
        {

            string result = stalcraftAPIExternal.GetItemPriceHistory(itemId).Result;
            return result;
        }
    }
}
