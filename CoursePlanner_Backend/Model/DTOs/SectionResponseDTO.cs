using CoursePlanner_Backend.Model.Entities;

namespace CoursePlanner_Backend.Model.DTOs
{
    public class SectionResponseDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Credit_Min { get; set; }
        public double Credit_Max { get; set; }
        public List<CourseDTO> Courses { get; set; }

        public void ConvertToDTO(Section section)
        {
            this.Id = section.Id;
            this.Name = section.Name;
            this.Credit_Min = section.Credit_Min;
            this.Credit_Max = section.Credit_Max;
            this.Courses = new List<CourseDTO>();
            foreach (Course c in section.Courses)
            {
                CourseDTO tmp = new CourseDTO();
                tmp.ConvertToDTO(c);
                this.Courses.Add(tmp);
            }
        }
    }
}
