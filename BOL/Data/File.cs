using System;
using System.Collections.Generic;

namespace BOL.Data
{
    public partial class File
    {
        public int Id { get; set; }
        public string Description { get; set; } = null!;
        public string Name { get; set; } = null!;

        public virtual Lecture IdNavigation { get; set; } = null!;
    }
}
