using System.Collections.Generic;

namespace DTO
{
    public class CourseDTO
    {
        public int CourseID { get; set; }
        public string Title { get; set; }
        public int Credits { get; set; }

        public ICollection<EnrollmentDTO> Enrollments { get; set; }
    }
}