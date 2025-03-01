using Microsoft.AspNetCore.Mvc;

namespace ApiLoja.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
