namespace AuctionHelperSC.Api.ServiceInterfaces
{
    public interface IStalcraftGitHubExternalService
    {
        public Task<string> GetListing();
    }
}
