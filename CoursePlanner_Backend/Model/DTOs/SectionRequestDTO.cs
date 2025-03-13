namespace CoursePlanner_Backend.Model.DTOs
{
    public class SectionRequestDTO
    {
        public string Name { get; set; }
        public double Credit_Min { get; set; }
        public double Credit_Max { get; set; }
        public int MajorId { get; set; }
        public List<int> CourseIds { get; set; }
    }
}
