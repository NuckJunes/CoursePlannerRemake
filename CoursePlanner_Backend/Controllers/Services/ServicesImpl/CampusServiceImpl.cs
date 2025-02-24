using CoursePlanner_Backend.Controllers.Repositories;
using CoursePlanner_Backend.Model.DTOs;
using CoursePlanner_Backend.Model.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CoursePlanner_Backend.Controllers.Services.ServicesImpl
{
    public class CampusServiceImpl : ICampusService
    {
        public ICampusRepository campusRepository;

        public CampusServiceImpl(ICampusRepository campusRepository)
        {
            this.campusRepository = campusRepository;
        }

        public async Task<ActionResult<IEnumerable<CampusDTO>>> GetAllCampuses()
        {
            //Call repo and convert campus to campusDTO
            ActionResult<IEnumerable<Campus>> result = await campusRepository.GetAllCampuses();
            List<CampusDTO> campusDTOs = new List<CampusDTO>();
            foreach (Campus campus in result.Value)
            {
                CampusDTO c = new CampusDTO();
                c.ConvertToDTO(campus);
                campusDTOs.Add(c);
            }
            return new ActionResult<IEnumerable<CampusDTO>>(campusDTOs);
        }
    }
}
