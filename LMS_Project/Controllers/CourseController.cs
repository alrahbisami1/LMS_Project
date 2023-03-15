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
        public IActionResult Details(int cid)
        {
            if (cid == null)
            {
                return NotFound();
            }

            var course = _icourse.GetCourseById(cid);
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
        public IActionResult Edit(int cid)
        {
            if (cid == null)
            {
                return NotFound();
            }

            var course = _icourse.GetCourseById(cid);
            ViewBag.CategoryId = new SelectList(_icategory.GetAllCategories(), "Id", "Name");
            if (course == null)
            {
                return NotFound();
            }
            return View(course);
        }

       
        [HttpPost]
        public IActionResult Edit(int cid, Course course)
        {
            if (cid != course.Id)
            {
                return NotFound();
            }

            try
            {
                _icourse.Update(course);

            }
            catch (DbUpdateConcurrencyException)
            {
                if (CourseExists(cid) == null)
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

        private Course CourseExists(int cid)
        {
            return _icourse.GetCourseById(cid);
        }

        //====================================================

        public IActionResult Delete(int cid)
        {
            if (cid == null)
            {
                return NotFound();
            }

            var course = _icourse.GetCourseById(cid);
            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        // POST: Projects/Delete/5
        [HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int cid)
        {
            
            var course =  _icourse.GetCourseById(cid);
            if (course != null)
            {
                _icourse.Delete(cid);
            }


            return RedirectToAction(nameof(Index));
        }




    }
}
