namespace CoursePlanner_Backend.Model.Entities
{
    public class Campus
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Course> Courses { get; set; }
    }
}
