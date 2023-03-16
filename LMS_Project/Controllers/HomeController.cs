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
        private readonly ICategory _category;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IUser _user;
        private readonly ICourse _course;

        public HomeController(ICategory category, UserManager<IdentityUser> userManager, IUser user, ICourse course)
        {
            _category = category;
            _userManager = userManager;
            _user = user;
            _course = course;
        }

        public IActionResult Index()
        {

            return View();
        }
        public IActionResult OwnCourse()
        {
            var name = User.Identity.Name;
            var useridentity = _userManager.Users.FirstOrDefault(x => x.Email == name);
            var uid = Guid.Parse(useridentity.Id);
            var u = _user.GetAllUserCourses().Where(x => x.UserId == uid);
            
            return View(u);
        }

        public IActionResult StudentEnrollment(int id)
        {
            ViewBag.CategoryId = _category.GetAllCategories();
            var model = new List<Course>(); //emptylist
            if (User.Identity.IsAuthenticated )
            {

               var user= _user.GetAllUsers().SingleOrDefault(x => x.IsTeacher == false && x.UserName == User.Identity.Name);
                if (id != null && id != 0)
                {
                    _user.AssignUserCourse(user.Id, id);
                    ViewBag.msgsuccess = "User has been enrolled in the course!";

                }


               



            }
         
            return View(model);
        }

        public IActionResult filtercourses(int id)
        {
            ViewBag.CategoryId = _category.GetAllCategories();

            var model = _course.GetCoursesbyCatId(id);

            return View("StudentEnrollment", model);
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
        public IActionResult ChooseCourses(Guid userid, int[] courseid, User user)
        {

            ViewBag.UserId = new SelectList(_user.GetAllUsers().Where(x => x.IsTeacher==true), "Id", "UserName");
            ViewData["CourseId"] = new SelectList(_course.GetAllCourses(), "Id", "Name");
            if (user.IsTeacher == false && userid != null && courseid.Length > 0)
            {
                foreach (var cid in courseid)
                {
                    
                    _user.AssignUserCourse(userid, cid);

                }

            }


            

            var model = _user.GetAllUserCourses();

            return View(model);
        }


        //==========================================

        public IActionResult CourseHome()
        {
            return View(_course.GetAllCourses());
        }

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