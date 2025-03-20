using CoursePlanner_Backend.Controllers.Repositories;
using CoursePlanner_Backend.Model.DTOs;
using CoursePlanner_Backend.Model.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CoursePlanner_Backend.Controllers.Services.ServicesImpl
{
    public class MajorServiceImpl : IMajorService
    {
        public IMajorRepository MajorRepository;

        public MajorServiceImpl(IMajorRepository majorRepository)
        {
            MajorRepository = majorRepository;
        }
        public async Task<ActionResult<IEnumerable<MajorResponseDTO>>> GetMajors()
        {
            ActionResult<IEnumerable<Major>> majors = await MajorRepository.GetMajors();
            List<MajorResponseDTO> result = new List<MajorResponseDTO>();
            foreach(var m in majors.Value)
            {
                MajorResponseDTO tmp = new MajorResponseDTO();
                tmp.ConvertToDTO(m);
                result.Add(tmp);
            }

            return result;
        }
    }
}
