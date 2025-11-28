using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clinic.Application.DTOs;
using Clinic.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Clinic.API.Controllers;

[ApiController]
[Route("api/diseases")]
public class DiseaseController : ControllerBase
{
    private readonly IDiseaseService _diseaseService;

    public DiseaseController(IDiseaseService diseaseService)
    {
        _diseaseService = diseaseService;
    }


    [HttpGet]
    public async Task<ActionResult<IEnumerable<DiseaseDTO>>> GetAllDiseases()
    {
        var diseases = await _diseaseService.GetAllDiseasesAsync();
        return Ok(diseases);
    }
}
