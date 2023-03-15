using BOL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL
{
    public interface ILecture
    {

        void Add(Lecture lecture);
        void Update(Lecture lecture);
        void Delete(Lecture lecture);
        
        Lecture GetLectureById(int id);

        List<Lecture> GetAllLectures();

        public List<Course> GetAllCourses();
    }
}
