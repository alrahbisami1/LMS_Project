using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BOL;
using BOL.Data;

namespace DAL
{
    public class CategoryDAL : ICategory  
    {

        private readonly LMS_DB_identityContext _db;

        public CategoryDAL(LMS_DB_identityContext db)
        {
            _db = db;

        }

        public void Add(Category category)
        {
            _db.Categories.Add(category);
            _db.SaveChanges();
        }

        public void Delete(Category category)
        {
            _db.Categories.Remove(category);
            _db.SaveChanges();
        }

        public List<Category> GetAllCategories()
        {
            return _db.Categories.ToList();
        }

        public Category GetCategoryById(int id)
        {
            return _db.Categories.Find(id);
        }

       
        public void Update(Category category)
        {
            _db.Categories.Update(category);
            _db.SaveChanges();
        }
    }
}
