using CoursePlanner_Backend.Controllers.Repositories;
using CoursePlanner_Backend.Model.DTOs;
using CoursePlanner_Backend.Model.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CoursePlanner_Backend.Controllers.Services.ServicesImpl
{
    public class ScheduleServiceImpl : IScheduleService
    {
        public IScheduleRepository scheduleRepository;
        public ICourseRepository courseRepository;
        public IClassRepository classRepository;

        public ScheduleServiceImpl(IScheduleRepository scheduleRepository, ICourseRepository courseRepository, IClassRepository classRepository)
        {
            this.scheduleRepository = scheduleRepository;
            this.courseRepository = courseRepository;
            this.classRepository = classRepository;
        }

        public async Task<ActionResult<ScheduleResponseDTO>> CreateSchedule(ScheduleRequestDTO scheduleRequestDTO, int userId)
        {
            Schedule newSchedule = new Schedule();
            newSchedule.Name = scheduleRequestDTO.Name;
            newSchedule.classes = new List<Class>();

            // Take all classes and add them to database with connections to course and schedule
            foreach (ClassDTO c in scheduleRequestDTO.Classes)
            {
                Class newClass = new Class();
                newClass.schedule = newSchedule;
                newClass.year = c.year;
                newClass.semester = c.semester;

                // Connect course to class (Check for null/error)
                ActionResult<Course> course = await courseRepository.GetById(c.courseId);
                newClass.course = course.Value;

                // Add class to db using class repository (Check for null/error)
                ActionResult<Class> classAdded = await classRepository.AddClass(newClass);

                newSchedule.classes.Add(newClass);
            }

            ScheduleResponseDTO scheduleResponseDTO = new ScheduleResponseDTO();
            ActionResult<Schedule> result = await scheduleRepository.CreateSchedule(newSchedule);
            scheduleResponseDTO.ConvertToDTO(result.Value); //Check for null/error here
            return new ActionResult<ScheduleResponseDTO>(scheduleResponseDTO);
        }

        public async Task<ActionResult<ScheduleResponseDTO>> DeleteSchedule(int scheduleId)
        {
            ActionResult<Schedule> schedule = await scheduleRepository.DeleteSchedule(scheduleId);
            ScheduleResponseDTO responseDTO = new ScheduleResponseDTO();
            responseDTO.ConvertToDTO(schedule.Value);
            return new ActionResult<ScheduleResponseDTO>(responseDTO);
        }

        public async Task<ActionResult<ScheduleResponseDTO>> GetSchedule(int scheduleId)
        {
            ActionResult<Schedule> schedule = await scheduleRepository.GetSchedule(scheduleId);
            //convert to scheduleResponseDTO
            ScheduleResponseDTO scheduleDTO = new ScheduleResponseDTO();
            foreach(Class c in schedule.Value.classes)
            {
                ClassDTO classDTO = new ClassDTO();
                classDTO.ConvertToDTO(c);
                scheduleDTO.Classes.Add(classDTO);
            }
            return new ActionResult<ScheduleResponseDTO>(scheduleDTO);
        }

        public async Task<ActionResult<ScheduleResponseDTO>> UpdateSchedule(ScheduleRequestDTO scheduleRequestDTO, int scheduleId)
        {
            //get existing schedule
            ActionResult<Schedule> existingSchedule = await scheduleRepository.GetSchedule(scheduleId);
            Schedule schedule = existingSchedule.Value;
            schedule.Name = scheduleRequestDTO.Name;

            // Delete existing classes
            foreach(Class c in existingSchedule.Value.classes)
            {
                ActionResult<Class> d = await classRepository.DeleteClass(c);
            }

            // Add in new classes
            foreach(ClassDTO c in scheduleRequestDTO.Classes)
            {
                Class newClass = new Class();
                newClass.year = c.year;
                newClass.schedule = schedule;
                ActionResult<Course> course = await courseRepository.GetById(c.courseId);
                newClass.course = course.Value;
                newClass.semester = c.semester;
                await classRepository.AddClass(newClass);
            }

            // Send to Repository to Update
            ActionResult<Schedule> result = await scheduleRepository.UpdateSchedule(schedule);

            // Convert to a scheduleResponseDTO to return
            ScheduleResponseDTO scheduleResponseDTO = new ScheduleResponseDTO();
            scheduleResponseDTO.ConvertToDTO(schedule);
            return new ActionResult<ScheduleResponseDTO>(scheduleResponseDTO);
            throw new NotImplementedException();
        }
    }
}
