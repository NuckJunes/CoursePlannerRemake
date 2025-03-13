using CoursePlanner_Backend.Controllers.Repositories;
using CoursePlanner_Backend.Model.DTOs;
using CoursePlanner_Backend.Model.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CoursePlanner_Backend.Controllers.Services.ServicesImpl
{
    public class MajorService : IMajorService
    {
        public IMajorRepository MajorRepository;

        public MajorService(IMajorRepository majorRepository)
        {
            MajorRepository = majorRepository;
        }
        public async Task<ActionResult<IEnumerable<MajorResponseDTO>>> GetMajors()
        {
            IEnumerable<ActionResult<Major>> majors = await MajorRepository.GetMajors();
            List<MajorResponseDTO> result = new List<MajorResponseDTO>();
            foreach(var m in majors)
            {
                MajorResponseDTO tmp = new MajorResponseDTO();
                tmp.ConvertToDTO(m.Value);
                result.Add(tmp);
            }

            return result;
        }
    }
}
