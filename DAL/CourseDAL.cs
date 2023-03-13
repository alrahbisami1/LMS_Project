using BOL;
using BOL.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class CourseDAL : ICourse
    {
        private readonly LMSDBContext _db;

        public CourseDAL(LMSDBContext db)
        {
            _db = db;

        }
        public void Add(Course course)
        {
            _db.Add(course);
            _db.SaveChanges();
        }

        public void Delete(Course course)
        {
           _db.Remove(course);
            _db.SaveChanges();
        }

        public List<Course> GetAllCourses()
        {
            return _db.Courses.ToList();
        }

        public Course GetCourseById(int id)
        {
            return _db.Courses.Find(id);
        }

        public List<Course> GetCoursesbyCatId(int catId)
        {
            var catCourses = _db.Courses.Where(x => x.CategoryId == catId).ToList();
            return catCourses;
        }

        //public List<UserCourses> GetuserCourses()
        //{
        //    return _db.UserCourses.Include(x => x.User).Include(y => y.Course).ToList();
        //}

        public void Update(Course course)
        {
            _db.Update(course);
            _db.SaveChanges();

        }
    }
}
