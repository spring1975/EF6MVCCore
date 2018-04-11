using System.Collections.Generic;
using System.Threading.Tasks;
using DTO;

namespace SchoolService.Interfaces
{
    public interface IStudentService
    {
        Task<IEnumerable<StudentDTO>> GetStudents();
        Task<StudentDTO> GetStudent(int id);
        Task<int> AddStudent(StudentDTO student);
        Task<int> EditStudent(StudentDTO student);
        Task<int> DeleteStudent(int id);
    }
}