using LMS_Project.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.AspNetCore.Identity;
using BOL.Data;
using BOL;

namespace LMS_Project.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IUser _user;

        public HomeController(UserManager<IdentityUser> userManager, IUser user)
        {
            this._userManager = userManager;
            _user = user;
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