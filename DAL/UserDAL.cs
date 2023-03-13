using BOL;
using BOL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class UserDAL : IUser
    {
        private readonly LMSDB_identityContext _db;

        public UserDAL(LMSDB_identityContext db)
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
    }
}
