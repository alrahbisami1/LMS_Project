using System;
using System.Collections.Generic;

namespace BOL.Data
{
    public partial class File
    {
        public int Id { get; set; }
        public string Description { get; set; } = null!;
        public string Path { get; set; } = null!;
        public int LectureId { get; set; }

        public virtual Lecture Lecture { get; set; } = null!;
    }
}
