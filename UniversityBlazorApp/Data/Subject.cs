using System;
using System.Collections.Generic;

namespace UniversityBlazorApp.Data
{
    public partial class Subject
    {
        public Subject()
        {
            Marks = new HashSet<Mark>();
            TeachersToSubjects = new HashSet<TeachersToSubject>();
        }

        public int Id { get; set; }
        public string Subject1 { get; set; } = null!;

        public virtual ICollection<Mark> Marks { get; set; }
        public virtual ICollection<TeachersToSubject> TeachersToSubjects { get; set; }
    }
}
