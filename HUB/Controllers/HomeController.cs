using HUB.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Newtonsoft.Json;

namespace HUB.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> random()
        {
            string apiUrl = "https://hp-api.herokuapp.com/api/characters";
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    var response = await client.GetStringAsync(apiUrl);
                    List<dynamic> characters = JsonConvert.DeserializeObject<List<dynamic>>(response);
                    ViewBag.Characters = characters;
                }
                catch (HttpRequestException ex)
                {
                    ViewBag.Error = $"Request error: {ex.Message}";
                }
                catch (Exception ex)
                {
                    ViewBag.Error = $"An error occurred: {ex.Message}";
                }
            }

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
