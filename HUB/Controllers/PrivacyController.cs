using Microsoft.AspNetCore.Mvc;

namespace HUB.Controllers
{
    public class PrivacyController : Controller
    {
        public async Task<ActionResult> Privacy()
        {
            return View();
        }
    }
}
