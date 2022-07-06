﻿using System.Collections.Generic;
using System.Threading.Tasks;

namespace UniversityBlazorApp.Data
{
    public interface IPostgreSQLService
    {
        Task<List<Student>> GetStudentsAsync();
        Task<Student> GetStudentAsync(int id);
        Task<Student> CreateStudentAsync(Student c);
        Task<Student> UpdateStudentAsync(Student c);
        Task DeleteStudentAsync(int id);
    }
}
