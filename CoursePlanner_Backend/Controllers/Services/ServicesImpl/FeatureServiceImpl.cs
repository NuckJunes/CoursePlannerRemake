using CoursePlanner_Backend.Controllers.Repositories;
using CoursePlanner_Backend.Model.DTOs;
using CoursePlanner_Backend.Model.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CoursePlanner_Backend.Controllers.Services.ServicesImpl
{
    public class FeatureServiceImpl : IFeatureService
    {
        public IFeatureRepository featureRepository;

        public FeatureServiceImpl(IFeatureRepository featureRepository)
        {
            this.featureRepository = featureRepository;
        }
        public async Task<ActionResult<IEnumerable<FeatureDTO>>> GetAllFeatures()
        {
            ActionResult<IEnumerable<Feature>> result = await featureRepository.GetAllFeatures();
            List<FeatureDTO> featureDTOs = new List<FeatureDTO>();
            foreach(Feature feature in result.Value)
            {
                FeatureDTO f = new FeatureDTO();
                f.ConvertToDTO(feature);
                featureDTOs.Add(f);
            }
            return new ActionResult<IEnumerable<FeatureDTO>>(featureDTOs);
        }
    }
}
