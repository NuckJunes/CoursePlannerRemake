﻿using CoursePlanner_Backend.Model.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CoursePlanner_Backend.Controllers.Repositories
{
    public interface IFeatureRepository
    {
        Task<ActionResult<IEnumerable<Feature>>> GetAllFeatures();
        Task<ActionResult<Feature>> GetById(int id);
    }
}
