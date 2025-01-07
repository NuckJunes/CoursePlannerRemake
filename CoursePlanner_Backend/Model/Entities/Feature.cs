namespace CoursePlanner_Backend.Model.Entities
{
    public class Feature
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Short_Name { get; set; }
        public List<Course> Courses { get; set; }
    }
}
