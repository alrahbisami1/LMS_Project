using System;
using System.Collections.Generic;
using BOL.Data;

namespace BOL.Data
{
    public partial class User
    {
        public User()
        {
            UserCourses = new HashSet<UserCourse>();
        }

        public Guid Id { get; set; }
        public string UserName { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public bool IsTeacher { get; set; }

        public virtual ICollection<UserCourse> UserCourses { get; set; }
    }
}
