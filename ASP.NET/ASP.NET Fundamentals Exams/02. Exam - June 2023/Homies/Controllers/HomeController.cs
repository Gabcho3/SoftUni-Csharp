using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Homies.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            if (User.Identity != null && User.Identity!.IsAuthenticated)
            {
                return RedirectToAction("All", "Event");
            }

            return View();
        }
    }
}