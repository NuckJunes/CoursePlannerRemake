using CoursePlanner_Backend.Model.Entities;

namespace CoursePlanner_Backend.Model.DTOs
{
    public class ClassInsertDTO
    {
        public String semester { get; set; }
        public int year { get; set; }
        public int courseId { get; set; }

        public void ConvertToDTO(Class classToConvert)
        {
            this.semester = classToConvert.semester;
            this.year = classToConvert.year;
            this.courseId = classToConvert.course.Id;
        }
    }
}
