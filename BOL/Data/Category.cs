using System;
using System.Collections.Generic;

namespace BOL.Data
{
    public partial class Category
    {
        public Category()
        {
            Courses = new HashSet<Course>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Course> Courses
        { 
            get; set;
        
        }


    }
}
