using BOL;
using BOL.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace LMS_Project.Controllers
{
    public class LectureController : Controller
    {
        private readonly ILecture _context;
        private readonly ICourse _course;
        public LectureController(ILecture context, ICourse course)
        {
            _context = context;
            _course = course;
        }

        // GET: LectureController
        public ActionResult Index()
        {
            ViewBag.CourseId = new SelectList(_course.GetAllCourses(), "Id", "Name");
            return View(_context.GetAllLectures());
        }

        // GET: LectureController/Details/5
        [HttpGet]
        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var lecture = _context.GetLectureById(id);
            if (lecture == null)
            {
                return NotFound();
            }
            ViewBag.CourseId = new SelectList(_course.GetAllCourses(), "Id", "Name");
            return View(lecture);
        }

        // GET: LectureController/Create
        public ActionResult Create()
        {
            ViewBag.CourseId = new SelectList(_course.GetAllCourses(), "Id", "Name");
            return View();
        }

        // POST: LectureController/Create
        [HttpPost]

        public ActionResult Create(Lecture lecture)
        {
            _context.Add(lecture);
            return RedirectToAction(nameof(Index));
        }

        // GET: LectureController/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lecture =  _context.GetLectureById(id);
            ViewBag.CourseId = new SelectList(_course.GetAllCourses(), "Id", "Name");
            if (lecture == null)
            {
                return NotFound();
            }
            return View(lecture);
        }

        // POST: LectureController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id,Lecture lecture)
        {
            if (id != lecture.Id)
            {
                return NotFound();
            }
                try
                {
                    _context.Update(lecture);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (LectureExists(id) == null)
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

        // GET: LectureController/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var lecture =  _context.GetLectureById(id);
            if (lecture == null)
            {
                return NotFound();
            }

            return View(lecture);
        }

        // POST: LectureController/Delete/5
        [HttpPost , ActionName("Delete")]
     
        public ActionResult DeleteConfirmed(int id)
        {
            var lecture = _context.GetLectureById(id);
            if (lecture != null)
            {
                _context.Delete(lecture);
            }
            return RedirectToAction(nameof(Index));
        }
        private Lecture LectureExists(int id)
        {
            return _context.GetLectureById(id);
        }
    }
}
