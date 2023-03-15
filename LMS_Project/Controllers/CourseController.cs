using BOL;
using BOL.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
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

        public IActionResult Index()
        {
            ViewBag.CategoryId = new SelectList(_icategory.GetAllCategories(), "Id", "Name");
            var model = _icourse.GetAllCourses();


            return View(model);

        }
        //============================================
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

        //=============================================
        public IActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(_icategory.GetAllCategories(), "Id", "Name");
            return View();
        }


        [HttpPost]
        public IActionResult Create(Course course)
        {
            ViewBag.CategoryId = new SelectList(_icategory.GetAllCategories(), "Id", "Name");


                _icourse.Add(course);

                ModelState.Clear();
           

            return View();

        }
        //================================================
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
        //[ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            
            var course =  _icourse.GetCourseById(id);
            if (course != null)
            {
                _icourse.Delete(course);
            }


            return RedirectToAction(nameof(Index));
        }




    }
}
