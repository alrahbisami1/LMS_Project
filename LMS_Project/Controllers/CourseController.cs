using Microsoft.AspNetCore.Mvc;

namespace LMS_Project.Controllers
{
    public class CourseController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
