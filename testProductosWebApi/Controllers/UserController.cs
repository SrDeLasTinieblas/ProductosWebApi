using Microsoft.AspNetCore.Mvc;

namespace testProductosWebApi.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
