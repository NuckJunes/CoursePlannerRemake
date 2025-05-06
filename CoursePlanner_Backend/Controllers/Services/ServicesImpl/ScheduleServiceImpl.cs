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
        public IAccountRepository accountRepository;
        public ScheduleServiceImpl(IScheduleRepository scheduleRepository, ICourseRepository courseRepository, IClassRepository classRepository, IAccountRepository accountRepository)
        {
            this.scheduleRepository = scheduleRepository;
            this.courseRepository = courseRepository;
            this.classRepository = classRepository;
            this.accountRepository = accountRepository;
        }

        public async Task<ActionResult<ScheduleResponseDTO>> CreateSchedule(ScheduleRequestDTO scheduleRequestDTO, int userId)
        {
            Schedule newSchedule = new Schedule();
            newSchedule.Name = scheduleRequestDTO.Name;
            newSchedule.classes = new List<Class>();
            ActionResult<User> u = await accountRepository.GetUser(userId);
            newSchedule.user = u.Value;

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
                //ActionResult<Class> classAdded = await classRepository.AddClass(newClass);
                newSchedule.classes.Add(newClass);
            }

            ScheduleResponseDTO scheduleResponseDTO = new ScheduleResponseDTO();
            newSchedule.Id = 0;
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
            scheduleDTO.Name = schedule.Value.Name;
            scheduleDTO.Id = schedule.Value.Id;
            scheduleDTO.Classes = new List<ClassDTO>();
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
            existingSchedule.Value.Name = scheduleRequestDTO.Name;

            foreach(ClassDTO c in  scheduleRequestDTO.Classes)
            {
                //Replace all instances of class insert dto with ClassDTO
                ActionResult<Class> tmp = await classRepository.GetClass(c.id);
                if (tmp != null)
                {
                    tmp.Value.course = courseRepository.GetById(c.id).Result.Value;
                    tmp.Value.year = c.year;
                    tmp.Value.semester = c.semester;
                } else
                {
                    Class newClass = new Class();
                    newClass.schedule = existingSchedule.Value;
                    newClass.course = courseRepository.GetById(c.id).Result.Value;
                    newClass.year = c.year;
                    newClass.semester = c.semester;
                    classRepository.AddClass(newClass);
                }
            }

            // Send to Repository to Update
            ActionResult<Schedule> result = await scheduleRepository.UpdateSchedule(existingSchedule.Value);

            // Convert to a scheduleResponseDTO to return
            ScheduleResponseDTO scheduleResponseDTO = new ScheduleResponseDTO();
            scheduleResponseDTO.ConvertToDTO(result.Value);
            return new ActionResult<ScheduleResponseDTO>(scheduleResponseDTO);
            throw new NotImplementedException();
        }
    }
}
