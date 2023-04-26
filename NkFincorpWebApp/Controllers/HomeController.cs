using Microsoft.AspNetCore.Mvc;

namespace NkFincorpWebApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult MainPage()
        {
            return View();
        }
    }
}
