using DTO;
using EF6.Models;

namespace SchoolService.Mappers
{
    public static class StudentMapperExtensions
    {
        public static StudentDTO AsDTO(this Student student)
        {
            var studentDto = new StudentDTO
            {
                EnrollmentDate = student.EnrollmentDate,
                FirstMidName = student.FirstMidName,
                ID = student.ID,
                LastName = student.LastName
            };

            return studentDto;
        }

        public static Student FromDTO(this StudentDTO studentDto)
        {
            var student = new Student
            {
                EnrollmentDate = studentDto.EnrollmentDate,
                FirstMidName = studentDto.FirstMidName,
                ID = studentDto.ID,
                LastName = studentDto.LastName
            };

            return student;
        }

    }
}
