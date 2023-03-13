using System;
using System.Collections.Generic;

namespace BOL.Data
{
    public partial class UserCourse
    {
        public Guid UserId { get; set; }
        public int CourseId { get; set; }
        public int Id { get; set; }

        public virtual Course Course { get; set; } = null!;
        public virtual User User { get; set; } = null!;
    }
}
