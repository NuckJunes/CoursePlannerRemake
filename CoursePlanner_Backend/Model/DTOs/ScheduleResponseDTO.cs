using CoursePlanner_Backend.Model.Entities;

namespace CoursePlanner_Backend.Model.DTOs
{
    public class ScheduleResponseDTO
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public List<Class> Classes { get; set; }
    }
}
