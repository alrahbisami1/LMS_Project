using BOL;
using BOL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class LectureDAL : ILecture
    {
        private readonly LMSDB_identityContext _db;

        public LectureDAL(LMSDB_identityContext db)
        {
            _db = db;

        }

        public void Add(Lecture lecture)
        {
            _db.Lectures.Add(lecture);
              _db.SaveChanges();

        }

        public void Delete(Lecture lecture)
        {
            _db.Lectures.Remove(lecture);
            _db.SaveChanges();
        }

        public List<Lecture> GetAllLectures()
        {
         return  _db.Lectures.ToList();
        }

        public Lecture GetLectureById(int id)
        {
            return _db.Lectures.Find(id);

        }

        public void Update(Lecture lecture)
        {
            _db.Lectures.Update(lecture);
            _db.SaveChanges();
        }
    }
}
