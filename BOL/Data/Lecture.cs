using System;
using System.Collections.Generic;

namespace BOL.Data
{
    public partial class Lecture
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Content { get; set; } = null!;
        public int CourseId { get; set; }

        public virtual Course Course { get; set; } = null!;
        public virtual File? File { get; set; }
    }
}
