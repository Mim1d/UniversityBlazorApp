using System;
using System.Collections.Generic;

namespace UniversityBlazorApp.Data
{
    public partial class Mark
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int SubjectId { get; set; }
        public int? Mark1 { get; set; }
        public int TeacherId { get; set; }
        public DateOnly MarkDate { get; set; }

        public virtual Student Student { get; set; } = null!;
        public virtual Subject Subject { get; set; } = null!;
        public virtual Teacher Teacher { get; set; } = null!;
    }
}
