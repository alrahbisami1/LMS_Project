using BOL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL
{
    public interface ICategory
    {
        void Add(Category category);
        void Update(Category category);
        void Delete(Category category);
       
        Category GetCategoryById(int id);

        List<Category> GetAllCategories();

    }
}
