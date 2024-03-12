using Microsoft.AspNetCore.Mvc;

namespace Asp.net_Core_Web_App_MVC_E_Commerce.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
