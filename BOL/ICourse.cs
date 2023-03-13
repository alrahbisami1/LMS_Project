using BOL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
//using CourseCat = BOL.Data.Category;

namespace BOL
{
    public interface ICourse
    {

        void Add(Course course);
        void Update(Course course);
        void Delete(Course course);
        
        Course GetCourseById(int id);

        List<Course> GetAllCourses();

        List<Course> GetCoursesbyCatId(int catId);

        List <Course> GetuserCourses();
    }
}
