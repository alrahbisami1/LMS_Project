using BOL;
using BOL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DAL
{
    public class FileDAL : IFileData
    {


        private readonly LMS_DB_identityContext _db;

        public FileDAL(LMS_DB_identityContext db)
        {
            _db = db;

        }

        public void Add(BOL.Data.File file)
        {
            _db.Add(file);
            _db.SaveChanges();

        }

        public void Delete(BOL.Data.File file)
        {
           _db.Files.Remove(file);
            _db.SaveChanges();
        }

        public List<BOL.Data.File> GetAllFiles()
        {
           return _db.Files.ToList();
        }

        public BOL.Data.File GetFileById(int id)
        {
           return _db.Files.Find(id);
        }

        public void Update(BOL.Data.File file)
        {
            _db.Files.Update(file);
        }
    }
}
