using LMS_Project.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.AspNetCore.Identity;
using BOL.Data;
using BOL;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LMS_Project.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IUser _user;
        private readonly ICourse _course;

        public HomeController(UserManager<IdentityUser> userManager, IUser user, ICourse course)
        {
            this._userManager = userManager;
            _user = user;
            _course = course;
        }

        public IActionResult Index()
        {

            return View();
        }
        public IActionResult CreateUser()
        {

            return View();
        }
        [HttpPost]
        public IActionResult CreateUser(User user)
        {
            var name = User.Identity.Name;
            var useridentity = _userManager.Users.FirstOrDefault(x => x.Email == name);

            user.Id = Guid.Parse(useridentity.Id);
            user.UserName = User.Identity.Name.ToString();
            _user.Add(user);

            return View();
        }

        //===============================
        public IActionResult ChooseCourses(Guid userid, int[] courseid)
        {

            ViewBag.UserId = new SelectList(_user.GetAllUsers(), "Id", "UserName");
            ViewData["CourseId"] = new SelectList(_course.GetAllCourses(), "Id", "Name");

            if (userid != null && courseid.Length > 0)
            {
                foreach (var cid in courseid)
                {
                    //عبارة عن مصفوفة، ويتم فحصها في كل دورة للتحقق من عدد المدخلات فيها ProjectID
                    //TeamProject بعدها يتم إضافة المدخلات في جدول 
                    _user.AssignUserCourse(userid, cid);

                }

            }

            var model = _user.GetAllUserCourses();

            return View(model);
        }


        //==========================================



        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}