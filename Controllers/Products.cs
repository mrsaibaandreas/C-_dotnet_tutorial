using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class Products : Controller
    {
        // GET
        public IActionResult Index()
        {
            return View();
        }
    }
}