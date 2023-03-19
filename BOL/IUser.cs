using BOL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL
{
    public interface IUser
    {
        void Add(User user);
        void Update(User user);
        void Delete(User user);
       
        User GetUserById(int id);
        void AssignUserCourse(Guid userid, int courseid);
        List<UserCourse> GetAllUserCourses();
        List<Lecture> GetUserLectureFiles();
       
        List<User> GetAllUsers();
    }
}
