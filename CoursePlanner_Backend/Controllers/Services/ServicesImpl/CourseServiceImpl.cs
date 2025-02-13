﻿using CoursePlanner_Backend.Controllers.Repositories;
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

        public async Task<ActionResult<IEnumerable<CourseResponseDTO>>> GetCourses()
        {
            //convert actionresult<IEnumerable<Course>> to ResponseDTOs
            ActionResult<IEnumerable<Course>> courses = await courseRepository.GetAllCourses();
            List<CourseResponseDTO> responses = new List<CourseResponseDTO>();
            foreach (var course in courses.Value)
            {
                CourseResponseDTO response = new CourseResponseDTO();
                response.ConvertToDTO(course);
                responses.Add(response);
            }
            return new ActionResult<IEnumerable<CourseResponseDTO>>(responses);
        }

        public async Task<ActionResult<Course>> GetById(int Id)
        {
            return await courseRepository.GetById(Id);
        }

        public async Task<ActionResult<CourseResponseDTO>> AddCourse(CourseRequestDTO courseRequestDTO)
        {
            //Convert DTO to Course Entity here
            Course course = new Course();
            course.Name = courseRequestDTO.Name;
            course.Description = courseRequestDTO.Description;
            course.Credit_Hours = courseRequestDTO.Credit_hours;
            course.Course_Number = courseRequestDTO.Course_Number;
            course.Subject = courseRequestDTO.Subject;
            course.Features = new List<Feature>();
            course.Campuses = new List<Campus>();
            course.Prerequisites = new List<Course>();

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

            ActionResult<Course> result = await courseRepository.AddCourse(course); //for security purposes

            //Conversion to responseDTO
            CourseResponseDTO response = new CourseResponseDTO();
            response.ConvertToDTO(course);
            return new ActionResult<CourseResponseDTO>(response);
        }

        public async Task<ActionResult<CourseResponseDTO>> UpdateCourse(CourseRequestDTO courseRequestDTO, int id)
        {
            ActionResult<Course> existingCourse = await this.GetById(id);
            Course course = existingCourse.Value;
            course.Name = courseRequestDTO.Name;
            course.Description = courseRequestDTO.Description;
            course.Credit_Hours = courseRequestDTO.Credit_hours;
            course.Course_Number = courseRequestDTO.Course_Number;
            course.Subject = courseRequestDTO.Subject;

            course.Features = new List<Feature>();
            course.Campuses = new List<Campus>();
            course.Prerequisites = new List<Course>();
            //Update features, campus, prereq

            foreach (int ID in courseRequestDTO.FeatureIds)
            {
                ActionResult<Feature> featureToAdd = await featureRepository.GetById(ID);
                course.Features.Add(featureToAdd.Value);
            }

            foreach (int ID in courseRequestDTO.CampusIds)
            {
                ActionResult<Campus> campusToAdd = await campusRepository.GetById(ID);
                course.Campuses.Add(campusToAdd.Value);
            }

            foreach (int ID in courseRequestDTO.PreReqIds)
            {
                ActionResult<Course> preReq = await this.GetById(id);
                course.Prerequisites.Add(preReq.Value);
            }

            ActionResult<Course> result = await courseRepository.UpdateCourse(course); // for security reasons

            CourseResponseDTO response = new CourseResponseDTO();
            response.ConvertToDTO(course);
            return new ActionResult<CourseResponseDTO>(response);
        }

        public async Task<ActionResult<CourseResponseDTO>> DeleteCourse(int id)
        {
            ActionResult<Course> result = await courseRepository.DeleteCourse(id);

            CourseResponseDTO response = new CourseResponseDTO();
            response.ConvertToDTO(result.Value);
            return new ActionResult<CourseResponseDTO>(response);
        }
    }
}
