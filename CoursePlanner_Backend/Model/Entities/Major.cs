namespace CoursePlanner_Backend.Model.Entities
{
    public class Major
    {
        public int Id { get; set; }
        public string Name {  get; set; }
        public string College { get; set; }
        public Boolean Graduate { get; set; }
        public double Credit_Min { get; set; }
        public double Credit_Max { get; set; }
        public List<Section> Sections { get; set; }
    }
}
