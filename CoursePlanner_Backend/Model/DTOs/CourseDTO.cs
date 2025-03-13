using CoursePlanner_Backend.Model.Entities;

namespace CoursePlanner_Backend.Model.DTOs
{
    public class CourseDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public void ConvertToDTO(Course course)
        {
            this.Id = course.Id;
            this.Name = course.Name;
            this.Description = course.Description;
        }
    }
}
