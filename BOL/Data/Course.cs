using System;
using System.Collections.Generic;
using BOL.Data;

namespace BOL.Data
{
    public partial class Course
    {
        public Course()
        {
            Lectures = new HashSet<Lecture>();
            UserCourses = new HashSet<UserCourse>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int CategoryId { get; set; }
        public bool IsActive { get; set; }

        public virtual Category Category { get; set; } = null!;
        public virtual ICollection<Lecture> Lectures { get; set; }
        public virtual ICollection<UserCourse> UserCourses { get; set; }
    }
}
