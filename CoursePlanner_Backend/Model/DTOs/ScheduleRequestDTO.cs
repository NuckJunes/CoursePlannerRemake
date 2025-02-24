using CoursePlanner_Backend.Model.Entities;

namespace CoursePlanner_Backend.Model.DTOs
{
    public class ScheduleRequestDTO
    {
        public String Name { get; set; }
        public List<ClassDTO> Classes { get; set; }
    }
}
