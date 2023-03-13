using System;
using System.Collections.Generic;

namespace BOL.Data
{
    public partial class Course
    {
        public Course()
        {
            Lectures = new HashSet<Lecture>();
            Students = new HashSet<User>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Price { get; set; }
        public int CategoryId { get; set; }
        public Guid TeacherId { get; set; }

        public virtual Category Category { get; set; } = null!;
        public virtual User Teacher { get; set; } = null!;
        public virtual ICollection<Lecture> Lectures { get; set; }

        public virtual ICollection<User> Students { get; set; }
    }
}
