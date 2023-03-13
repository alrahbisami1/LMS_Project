using BOL;
using BOL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class CourseDAL : ICourse
    {
        private readonly LMSDB_identityContext _db;

        public CourseDAL(LMSDB_identityContext db)
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

        public void Update(Course course)
        {
            _db.Update(course);
            _db.SaveChanges();

        }
    }
}
