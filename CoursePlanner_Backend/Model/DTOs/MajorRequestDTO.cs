namespace CoursePlanner_Backend.Model.DTOs
{
    public class MajorRequestDTO
    {
        public string Name { get; set; }
        public string College { get; set; }
        public Boolean Graduate { get; set; }
        public double Credit_Min { get; set; }
        public double Credit_Max { get; set; }
        public List<int> SectionIds { get; set; }
    }
}
