using System;
using System.Collections.Generic;

namespace UniversityBlazorApp.Data
{
    public partial class Teacher
    {
        public Teacher()
        {
            Marks = new HashSet<Mark>();
            TeachersToSubjects = new HashSet<TeachersToSubject>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string MiddleName { get; set; } = null!;
        public string FamilyName { get; set; } = null!;
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string Post { get; set; } = null!;
        public decimal Salary { get; set; }
        public DateOnly? Birthdate { get; set; }

        public virtual ICollection<Mark> Marks { get; set; }
        public virtual ICollection<TeachersToSubject> TeachersToSubjects { get; set; }
    }
}
