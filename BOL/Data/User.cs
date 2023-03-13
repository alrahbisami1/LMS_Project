using System;
using System.Collections.Generic;

namespace BOL.Data
{
    public partial class User
    {
        public User()
        {
            Courses = new HashSet<Course>();
            CoursesNavigation = new HashSet<Course>();
        }

        public Guid Id { get; set; }
        public string UserName { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public bool IsTeacher { get; set; }

        public virtual ICollection<Course> Courses { get; set; }

        public virtual ICollection<Course> CoursesNavigation { get; set; }
    }
}
