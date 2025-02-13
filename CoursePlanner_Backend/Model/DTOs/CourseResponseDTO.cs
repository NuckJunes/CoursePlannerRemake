using CoursePlanner_Backend.Model.Entities;

namespace CoursePlanner_Backend.Model.DTOs
{
    public class CourseResponseDTO
    {
        public int Id {  get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
        public double Credit_hours { get; set; }
        public String Subject { get; set; }
        public int Course_Number { get; set; }
        public List<FeatureDTO> FeatureDTOs { get; set; }
        public List<CampusDTO> CampusDTOs { get; set; }
        public List<PrereqDTO> PreReqDTOs { get; set; }

        public void ConvertToDTO(Course course)
        {
            //convert the course values to course DTO values
            this.Id = course.Id;
            this.Name = course.Name;
            this.Description = course.Description;
            this.Credit_hours = course.Credit_Hours;
            this.Subject = course.Subject;
            this.Course_Number = course.Course_Number;

            this.FeatureDTOs = new List<FeatureDTO>();
            this.CampusDTOs = new List<CampusDTO>();
            this.PreReqDTOs = new List<PrereqDTO>();

            //loop through these
            foreach (Feature feature in course.Features)
            {
                this.FeatureDTOs.Add(new FeatureDTO { Id = feature.Id, Name = feature.Name });
            }
            foreach (Campus campus in course.Campuses)
            {
                this.CampusDTOs.Add(new CampusDTO { Id = campus.Id, Name = campus.Name });
            }
            foreach (Course prereq in course.Prerequisites)
            {
                this.PreReqDTOs.Add(new PrereqDTO { Id = prereq.Id, Name = prereq.Name });
            }
        }
    }
}
