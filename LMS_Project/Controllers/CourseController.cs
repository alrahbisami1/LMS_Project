using BOL;
using BOL.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Data;
using System.IO;
using System.Security.Cryptography;

namespace LMS_Project.Controllers
{
    
    public class CourseController : Controller
    {
        private readonly ICourse _icourse;
        private readonly IUser _iuser;
        private readonly ICategory _icategory;
        public CourseController(ICourse icourse, IUser iuser, ICategory icategory)
        {
            _icourse = icourse;
            _iuser = iuser;
            _icategory = icategory;
        }
        [Authorize(Roles = "Admin, Teacher, Student")]
        public IActionResult Index()
        {
            ViewBag.CategoryId = new SelectList(_icategory.GetAllCategories(), "Id", "Name");
            var model = _icourse.GetAllCourses();


            return View(model);

        }
        //============================================
        [Authorize(Roles = "Admin, Teacher, Student")]
        public IActionResult Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = _icourse.GetCourseById(id);
            ViewBag.CategoryId = new SelectList(_icategory.GetAllCategories(), "Id", "Name");
            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }
        [Authorize(Roles = "Admin")]
        //=============================================
        public IActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(_icategory.GetAllCategories(), "Id", "Name");
            return View();
        }


        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Create(Course course)
        {
            ViewBag.CategoryId = new SelectList(_icategory.GetAllCategories(), "Id", "Name");


                _icourse.Add(course);

                ModelState.Clear();
           

            return View();

        }
        //================================================
        [Authorize(Roles = "Admin")]
        public IActionResult Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = _icourse.GetCourseById(id);
            ViewBag.CategoryId = new SelectList(_icategory.GetAllCategories(), "Id", "Name");
            if (course == null)
            {
                return NotFound();
            }
            return View(course);
        }

       
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Edit(int id, Course course)
        {
            if (id != course.Id)
            {
                return NotFound();
            }

            try
            {
                _icourse.Update(course);

            }
            catch (DbUpdateConcurrencyException)
            {
                if (CourseExists(id) == null)
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
          
            }
            return RedirectToAction(nameof(Index));
           





        }
        //=================================================

        private Course CourseExists(int id)
        {
            return _icourse.GetCourseById(id);
        }

        //====================================================
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = _icourse.GetCourseById(id);
            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        // POST: Projects/Delete/5
        [HttpPost, ActionName("Delete")]
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteConfirmed(int id)
        {
            
            var course =  _icourse.GetCourseById(id);
            if (course != null)
            {
                _icourse.Delete(course);
            }


            return RedirectToAction(nameof(Index));
        }
        //=================================================
        [Authorize(Roles = "Admin")]
        public IActionResult CatogryCourse(int id)
        {

            var catcourse = _icourse.GetCoursesbyCatId(id);
            if (catcourse == null)
            {
                return RedirectToAction("index");
            }


            return View(catcourse);

        }



    }
}
