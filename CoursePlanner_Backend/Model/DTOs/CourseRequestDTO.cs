namespace CoursePlanner_Backend.Model.DTOs
{
    public class CourseRequestDTO
    {
        public String Name { get; set; }
        public String Description { get; set; }
        public double Credit_hours { get; set; }
        public String Subject { get; set; }
        public int Course_Number { get; set; }
        public List<int> FeatureIds { get; set; }
        public List<int> CampusIds { get; set; }
        public List<int> PreReqIds { get; set; }
    }
}
