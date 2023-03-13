using BOL;
using BOL.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LMS_Project.Controllers
{
    public class LectureController : Controller
    {

        private readonly ILecture _context;

        public LectureController(ILecture context)
        {
            _context = context;
        }

        // GET: LectureController
        public ActionResult Index()
        {
            return View(_context.GetAllLectures());
        }

        // GET: LectureController/Details/5
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

            return View(lecture);
        }

        // GET: LectureController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LectureController/Create
        [HttpPost]

        public ActionResult Create([Bind("Id,Title,Content")] Lecture lecture)
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
            if (lecture == null)
            {
                return NotFound();
            }
            return View(lecture);
        }

        // POST: LectureController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, [Bind("Id,Title,Content")] Lecture lecture)
        {
            if (id != lecture.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
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
            return View(lecture);
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
        [ValidateAntiForgeryToken]
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
