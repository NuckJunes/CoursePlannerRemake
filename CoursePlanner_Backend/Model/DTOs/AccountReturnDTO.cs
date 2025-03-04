using CoursePlanner_Backend.Model.Entities;

namespace CoursePlanner_Backend.Model.DTOs
{
    public class AccountReturnDTO
    {
        public int Id { get; set; }
        public String Username { get; set; }
        public String Email { get; set; }
        public String Password { get; set; }
        public List<ScheduleResponseDTO> Schedules { get; set; }

        public void ConvertToDTO(User user)
        {
            this.Email = user.Email;
            this.Password = user.Password;
            this.Username = user.Username;
            this.Id = user.Id;
            this.Schedules = new List<ScheduleResponseDTO>();
            foreach(Schedule s in user.schedules)
            {
                ScheduleResponseDTO response = new ScheduleResponseDTO();
                response.ConvertToDTO(s);
                this.Schedules.Add(response);
            }
        }
    }
}
