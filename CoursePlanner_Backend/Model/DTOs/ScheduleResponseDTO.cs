using CoursePlanner_Backend.Model.Entities;

namespace CoursePlanner_Backend.Model.DTOs
{
    public class ScheduleResponseDTO
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public List<ClassDTO> Classes { get; set; }

        public void ConvertToDTO(Schedule schedule)
        {
            this.Id = schedule.Id;
            this.Name = schedule.Name;
            this.Classes = new List<ClassDTO>();
            foreach(Class c in schedule.classes)
            {
                ClassDTO newClassDTO = new ClassDTO();
                newClassDTO.ConvertToDTO(c);
                this.Classes.Add(newClassDTO);
            }
        }
    }
}
