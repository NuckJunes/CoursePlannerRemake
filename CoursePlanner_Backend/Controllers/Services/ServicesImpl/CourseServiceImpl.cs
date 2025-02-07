using CoursePlanner_Backend.Controllers.Repositories;
using CoursePlanner_Backend.Model.DTOs;
using CoursePlanner_Backend.Model.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CoursePlanner_Backend.Controllers.Services.ServicesImpl
{
    public class CourseServiceImpl : ICourseService
    {
        private ICourseRepository courseRepository;
        private ICampusRepository campusRepository;
        private IFeatureRepository featureRepository;

        public CourseServiceImpl(ICourseRepository courseRepository, ICampusRepository campusRepository, IFeatureRepository featureRepository)
        {
            this.courseRepository = courseRepository;
            this.campusRepository = campusRepository;
            this.featureRepository = featureRepository;
        }

        public async Task<ActionResult<IEnumerable<Course>>> GetCourses()
        {
            return await courseRepository.GetAllCourses();
        }

        public async Task<ActionResult<Course>> GetById(int Id)
        {
            return await courseRepository.GetById(Id);
        }

        public async Task<ActionResult<Course>> AddCourse(CourseRequestDTO courseRequestDTO)
        {
            //Convert DTO to Course Entity here
            Course course = new Course();
            course.Name = courseRequestDTO.Name;
            course.Description = courseRequestDTO.Description;
            course.Credit_Hours = courseRequestDTO.Credit_hours;
            course.Course_Number = courseRequestDTO.Course_Number;
            course.Subject = courseRequestDTO.Subject;

            foreach (int id in courseRequestDTO.FeatureIds)
            {
                ActionResult<Feature> featureToAdd = await featureRepository.GetById(id);
                course.Features.Add(featureToAdd.Value);
            }

            foreach (int id in courseRequestDTO.CampusIds)
            {
                ActionResult<Campus> campusToAdd = await campusRepository.GetById(id);
                course.Campuses.Add(campusToAdd.Value);
            }

            foreach (int id in courseRequestDTO.PreReqIds)
            {
                ActionResult<Course> preReq = await this.GetById(id);
                course.Prerequisites.Add(preReq.Value);
            }

            return await courseRepository.AddCourse(course);
        }

        public Task<ActionResult<Course>> UpdateCourse(CourseRequestDTO courseRequestDTO, int id)
        {
            throw new NotImplementedException();
        }
    }
}
