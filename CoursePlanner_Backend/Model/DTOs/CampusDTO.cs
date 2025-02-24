using CoursePlanner_Backend.Model.Entities;

namespace CoursePlanner_Backend.Model.DTOs
{
    public class CampusDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public void ConvertToDTO(Campus campus)
        {
            this.Id = campus.Id;
            this.Name = campus.Name;
        }
    }
}
