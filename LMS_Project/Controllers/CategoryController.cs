using BOL;
using BOL.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace LMS_Project.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategory _category;
        public CategoryController(ICategory category)
        {
            _category = category;
        }

        // GET: CategoryController
        public ActionResult Index()
        {
            return View(_category.GetAllCategories());
        }
        [HttpGet]
        // GET: CategoryController/Details/5
        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = _category.GetCategoryById(id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // GET: CategoryController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoryController/Create
        [HttpPost]

        public ActionResult Create(Category category)
        {
            _category.Add(category);
            return RedirectToAction(nameof(Index));
        }

        // GET: CategoryController/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = _category.GetCategoryById(id);

            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        // POST: CategoryController/Edit/5
        [HttpPost]

        public ActionResult Edit(int id, Category category)
        {
            if (id != category.Id)
            {
                return NotFound();
            }
            try
            {
                _category.Update(category);

            }
            catch (DbUpdateConcurrencyException)
            {
                if (CategoryExists(id) == null)
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
        [HttpGet]
        // GET: CategoryController/Delete/5
        public ActionResult Delete(int id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var category = _category.GetCategoryById(id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // POST: CategoryController/Delete/5
        [HttpPost]
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var category = _category.GetCategoryById(id);
            if (category != null)
            {
                _category.Delete(category);
            }
            return RedirectToAction(nameof(Index));
        }

        private Category CategoryExists(int id)
        {
            return _category.GetCategoryById(id);
        }
    }
}
