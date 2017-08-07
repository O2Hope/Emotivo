using Microsoft.AspNetCore.Mvc;

namespace Emotivo.Web.Controllers
{
    public class HomeController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return View();
        }
    }
}