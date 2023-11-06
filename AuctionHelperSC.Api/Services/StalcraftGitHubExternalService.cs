using Microsoft.AspNetCore.Mvc;
using AuctionHelperSC.Api.ServiceInterfaces;

namespace AuctionHelperSC.Api.Services
{
    public class StalcraftGitHubExternalService : IStalcraftGitHubExternalService
    {

        public async Task<string> GetListing()
        {

            string responseString = "";


            using (HttpClient httpClient = new HttpClient())
            {
                string downloadUrl = @"https://raw.githubusercontent.com/EXBO-Studio/stalcraft-database/main/ru/listing.json";
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, new Uri(downloadUrl));

                HttpResponseMessage response = httpClient.Send(request);

                responseString = await response.Content.ReadAsStringAsync();
            }

            return responseString;
        }
    }
}
