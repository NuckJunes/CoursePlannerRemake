using CoursePlanner_Backend.Model.Entities;

namespace CoursePlanner_Backend.Model.DTOs
{
    public class FeatureDTO
    {
        public int Id {  get; set; }
        public string Name { get; set; }

        public string Short_name { get; set; }

        public void ConvertToDTO(Feature feature)
        {
            this.Id = feature.Id;
            this.Name = feature.Name;
            this.Short_name = feature.Short_Name;
        }
    }
}
