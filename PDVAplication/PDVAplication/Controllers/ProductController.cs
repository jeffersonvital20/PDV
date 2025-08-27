using Microsoft.AspNetCore.Mvc;

namespace PDVAplication.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
