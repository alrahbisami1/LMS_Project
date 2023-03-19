using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace LMS_Project.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public AdminController(UserManager<IdentityUser> um, RoleManager<IdentityRole> rm)
        {
            _userManager = um;
            _roleManager = rm;
        }

        [HttpGet]
        public IActionResult CreateRoles()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateRoles(IFormCollection rolename)
        {
            try
            {
                var ir = new IdentityRole(); //role table
                ir.Name = rolename["txtRoleName"];//read from text
                ir.NormalizedName = rolename["txtRoleName"].ToString().ToUpper();//read from text
                await _roleManager.CreateAsync(ir); //add to role table
                return RedirectToAction("Index"); //display in index

            }
            catch (Exception)
            {

                throw;
            }


            return View();
        }

        public async Task<IActionResult> Index()
        {
            return View(await _roleManager.Roles.ToListAsync());
        }


        public async Task<IActionResult> AssignRole()
        {
            ViewBag.UserId = new SelectList(_userManager.Users, "Id", "Email");
            ViewBag.RoleId = new SelectList(_roleManager.Roles, "Id", "Name");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AssignRole(string RoleId, string UserId)
        {
            ViewBag.UserId = new SelectList(_userManager.Users, "Id", "Email");
            ViewBag.RoleId = new SelectList(_roleManager.Roles, "Id", "Name");

            if (!string.IsNullOrEmpty(RoleId) && !string.IsNullOrEmpty(UserId)
                && RoleId != "null" && UserId != "null")
            {
                var user = _userManager.Users.SingleOrDefault(x => x.Id == UserId);
                var s = ((SelectList)ViewBag.RoleId).Single(x => x.Value == RoleId).Text;

                //DDL.selectedText
                await _userManager.AddToRoleAsync(user, s);
            }

            return RedirectToAction();
        }

        public async Task<IActionResult> SortByRole(string RoleId)
        {
            ViewBag.RoleId = new SelectList(_roleManager.Roles, "Id", "Name");
            if (!string.IsNullOrEmpty(RoleId))
            {
                var s = ((SelectList)ViewBag.RoleId).Single(x => x.Value == RoleId).Text;
                var users = await _userManager.GetUsersInRoleAsync(s);
                return View(users);
            }

            else
            {
                return View();
            }
        }
    }
}
