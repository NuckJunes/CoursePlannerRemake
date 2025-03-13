namespace CoursePlanner_Backend.Model.Entities
{
    public class Section
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Credit_Min { get; set; }
        public double Credit_Max { get; set; }
        public Major Major { get; set; }
        public List<Course> Courses { get; set; }
    }
}
