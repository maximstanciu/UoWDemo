using Microsoft.AspNetCore.Mvc;

namespace UoWDemo.Controllers
{
    public class ApiController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
