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
    public class UserDAL : IUser
    {
        private readonly LMS_DB_identityContext _db;

        public UserDAL(LMS_DB_identityContext db)
        {
            _db = db;

        }

        public void Add(User user)
        {
            _db.Users.Add(user);
            _db.SaveChanges();
        }

        public void Delete(User user)
        {
            _db.Users.Remove(user); 
            _db.SaveChanges();
        }

        public List<User> GetAllUsers()
        {
            return _db.Users.ToList();
        }

        public User GetUserById(int id)
        {
            return _db.Users.Find(id);
        }

        public void Update(User user)
        {
           _db.Users.Update(user);
            _db.SaveChanges();
        }

        public void AssignUserCourse(Guid userid, int courseid)
        {
            
            var assign = new UserCourse() { UserId = userid, CourseId = courseid };
            _db.UserCourses.Add(assign);
            _db.SaveChanges();
        }

        public List<UserCourse> GetAllUserCourses()
        {
            //Eager Loading
            return _db.UserCourses.Include(x => x.User).Include(y => y.Course).ToList();
            //(Include) function dose not appere in tables that not contains FK
        }
    }
}
