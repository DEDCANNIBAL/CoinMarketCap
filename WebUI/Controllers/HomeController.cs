using Microsoft.AspNetCore.Mvc;

namespace CoinMarketCap.WebUI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
