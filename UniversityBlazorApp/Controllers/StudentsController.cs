using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniversityBlazorApp.Context;
using UniversityBlazorApp.Data;

namespace UniversityBlazorApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentsController : ControllerBase
    {
        private readonly universityContext db;

        public StudentsController (universityContext db)
        {
            this.db = db;
        }
        [HttpGet]
        public Task<List<Student>> GetStudentsAsync()
        {
            return db.Students.ToListAsync();
        }
        [HttpGet("{id}")]
        public Task<Student> GetStudentAsync(int id)
        {
            return db.Students.FirstOrDefaultAsync
            (c => c.Id == id);
        }
        [HttpPost]
        public async Task<Student> CreateStudentAsync(Student studentToAdd)
        {
            Student existing = await db.Students
                .FirstOrDefaultAsync
                (c => c.Id == studentToAdd.Id);
            if (existing == null)
            {
                db.Students.Add(studentToAdd);
                int affected = await db.SaveChangesAsync();
                if (affected == 1)
                {
                    return studentToAdd;
                }
            }
            return existing;
        }
        [HttpPut]
        public async Task<Student> UpdateStudentAsync(Student c)
        {
            db.Entry(c).State = EntityState.Modified;
            int affected = await db.SaveChangesAsync();
            if (affected == 1)
            {
                return c;
            }
            return null;
        }
        [HttpDelete("{id}")]
        public async Task<int> DeleteStudentAsync(int id)
        {
            Student c = await db.Students.FirstOrDefaultAsync
                (c => c.Id == id);
            if (c != null)
            {
                db.Students.Remove(c);
                int affected = await db.SaveChangesAsync();
                return affected;
            }
            return 0;
        }
    }

}
