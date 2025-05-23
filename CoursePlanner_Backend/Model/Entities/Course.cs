﻿namespace CoursePlanner_Backend.Model.Entities
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public double Credit_Hours { get; set; }
        public String Subject { get; set; }
        public int Course_Number { get; set; }
        public List<Feature> Features { get; set; }
        public List<Campus> Campuses { get; set; }
        public String PreRequisites { get; set; } //Stored as "(id || id (id && (id || id))"
        public List<Class> Classes { get; set; }

        public List<Section> Sections { get; set; }
    }
}
