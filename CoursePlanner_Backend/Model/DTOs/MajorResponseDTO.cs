using CoursePlanner_Backend.Model.Entities;

namespace CoursePlanner_Backend.Model.DTOs
{
    public class MajorResponseDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string College { get; set; }
        public Boolean Graduate { get; set; }
        public double Credit_Min { get; set; }
        public double Credit_Max { get; set; }
        public List<SectionResponseDTO> Sections { get; set; }

        public void ConvertToDTO(Major major)
        {
            this.Id = major.Id;
            this.Name = major.Name;
            this.College = major.College;
            this.Graduate = major.Graduate;
            this.Credit_Min = major.Credit_Min;
            this.Credit_Max = major.Credit_Max;
            this.Sections = new List<SectionResponseDTO>();
            foreach(var s in major.Sections)
            {
                SectionResponseDTO tmp = new SectionResponseDTO();
                tmp.ConvertToDTO(s);
                this.Sections.Add(tmp);
            }
        }
    }
}
