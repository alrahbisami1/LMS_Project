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
        private readonly LMS_DB_identityContext _db;

        public CourseDAL(LMS_DB_identityContext db)
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

        public void Delete(int id)
        {
            _db.Courses.Remove(GetCourseById(id));
            _db.SaveChangesAsync();
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

        //public Course GetCoursesByuserId(int? cid, int? userid)
        //{
        //    var userCourse = _db.UserCourses.Where(x => x.UserId == userid).ToList();
        //    return userCourse;
        //}

        public List<Course> GetCoursesbyUserId(Guid userid)
        {
            throw new NotImplementedException();
        }

        //public List<Course> GetuserCourses()
        //{
        //    return _db.UserCourses.Include(x => x.User).Include(y => y.Course).ToList();
        //}

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
