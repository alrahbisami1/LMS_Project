using Microsoft.AspNetCore.Mvc;

namespace LMS_Project.Controllers
{
    public class testController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
