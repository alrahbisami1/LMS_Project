using BOL;
using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace LMS_Project.Controllers
{
    public class CourseController : Controller
    {
        private readonly ICourse _icourse;
        private readonly IUser _iuser;
        public CourseController(ICourse icourse, IUser iuser)
        {
            _icourse = icourse;
            _iuser = iuser;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
