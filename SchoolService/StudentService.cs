using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using DTO;
using EF6;
using EF6.Models;
using SchoolService.Interfaces;
using SchoolService.Mappers;

namespace SchoolService
{
    public class StudentService: IStudentService
    {
        private readonly SchoolContext _context;

        public StudentService(SchoolContext schoolContext)
        {
            _context = schoolContext;
        }

        public async Task<IEnumerable<StudentDTO>> GetStudents()
        {
            var students = await _context.Students.ToListAsync();
            return students.Select(s => s.AsDTO());
        }

        public async Task<StudentDTO> GetStudent(int id)
        {
            var student = await GetStudentEntity(id);
            return student.AsDTO();
        }

        public async Task<int> AddStudent(StudentDTO studentDto)
        {
            var student = studentDto.FromDTO();
            _context.Students.Add(student);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> EditStudent(StudentDTO studentDto)
        {
            var student = studentDto.FromDTO();
            _context.Students.Attach(student);
            _context.Entry(student).State = EntityState.Modified;
            return await _context.SaveChangesAsync();

        }

        public async Task<int> DeleteStudent(int id)
        {
            var student = await _context.Students.SingleOrDefaultAsync(m => m.ID == id);
            if (student != null)
            {
                _context.Students.Remove(student);
            }

            return await _context.SaveChangesAsync();
        }

        private async Task<Student> GetStudentEntity(int id)
        {
            return await _context.Students.SingleOrDefaultAsync(m => m.ID == id);
        }
    }
}
