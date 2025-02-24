using CoursePlanner_Backend.Model.Entities;

namespace CoursePlanner_Backend.Model.DTOs
{
    public class ClassDTO
    {
        public int id { get; set; }
        public String semester { get; set; }
        public int year { get; set; }
        public int courseId { get; set; }

        public void ConvertToDTO(Class classToConvert) 
        {
            this.semester = classToConvert.semester;
            this.id = classToConvert.Id;
            this.year = classToConvert.year;
            this.courseId = classToConvert.course.Id;
        }

    }
}
