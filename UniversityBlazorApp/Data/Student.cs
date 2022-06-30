using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UniversityBlazorApp.Data
{
    public partial class Student
    {
        public Student()
        {
            Marks = new HashSet<Mark>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string MiddleName { get; set; } = null!;
        public string FamilyName { get; set; } = null!;
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public short? Class { get; set; }
        public DateOnly? Birthdate { get; set; }

        public virtual ICollection<Mark> Marks { get; set; }
    }
}
