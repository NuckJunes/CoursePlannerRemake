namespace CoursePlanner_Backend.Model.DTOs
{
    public class AccountCreateDTO
    {
        public String Username {  get; set; }
        public String Password { get; set; }
        public String Email { get; set; }
        public Boolean Admin {  get; set; }
    }
}
