using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using UniversityEntitiesLib;

namespace UniversityBlazorApp.Services

{
    public class PostgreSQLService : IPostgreSQLService
    {
        private readonly universityContext db;

        public PostgreSQLService(universityContext db)
        {
            this.db = db;
        }
        public Task<List<Student>> GetStudentsAsync()
        {
            return db.Students.ToListAsync();
        }
        public Task<Student> GetStudentAsync(int id)
        {
            return db.Students.FirstOrDefaultAsync
            (c => c.Id == id);
        }
        public Task<Student> CreateStudentAsync(Student c)
        {
            db.Students.Add(c);
            db.SaveChangesAsync();
            return Task.FromResult<Student>(c);
        }
        public Task<Student> UpdateStudentAsync(Student c)
        {
            db.Entry(c).State = EntityState.Modified;
            db.SaveChangesAsync();
            return Task.FromResult<Student>(c);
        }
        public Task DeleteStudentAsync(int id)
        {
            Student student = db.Students.Where(c => c.Id == id).FirstOrDefault();
            db.Students.Remove(student);
            return db.SaveChangesAsync();
        }
    }
}
