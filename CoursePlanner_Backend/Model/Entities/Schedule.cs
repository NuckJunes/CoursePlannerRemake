
namespace CoursePlanner_Backend.Model.Entities
{
    public class Schedule
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public User user { get; set; }
        public List<Class> classes { get; set; }
    }
}
