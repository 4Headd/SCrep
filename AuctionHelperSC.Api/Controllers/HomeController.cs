using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using AuctionHelperSC.Api.ServiceInterfaces;

namespace AuctionHelperSC.Api.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IStalcraftGitHubExternalService stalcraftGitHubExternalService;

        public HomeController(ILogger<HomeController> logger, IStalcraftGitHubExternalService stalcraftGitHubExternalService)
        {
            _logger = logger;
            this.stalcraftGitHubExternalService = stalcraftGitHubExternalService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Item(string slug)
        {
            ViewData["id"] = "/" + slug;
            string listingJson = stalcraftGitHubExternalService.GetListing().Result;


            if (listingJson.Contains(slug))
            {
                ViewData["icon"] = "https://raw.githubusercontent.com/EXBO-Studio/stalcraft-database/main/ru/icons/" + slug + ".png";
                ViewData["itemId"] = slug.Split('/').Last();
                return View();
            }
            else
            {
                return NotFound();
            }
        }
    }
}