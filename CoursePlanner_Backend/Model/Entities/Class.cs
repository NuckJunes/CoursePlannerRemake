namespace CoursePlanner_Backend.Model.Entities
{
    public class Class
    {
        public int Id { get; set; }
        public Schedule schedule { get; set; }
        public Course course { get; set; }
        public int year { get; set; }
        public String semester { get; set; }
    }
}
