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
[Route("api/doctors")]
public class DoctorController : ControllerBase
{
    private readonly IDoctorService _doctorService;

    public DoctorController(IDoctorService doctorService)
    {
        _doctorService = doctorService;
    }

    [HttpGet("by-disease")] 
    public async Task<ActionResult<IEnumerable<DoctorDTO>>> GetDoctorsByDiseaseId([FromQuery] Guid diseaseId)
    {
        if (diseaseId == Guid.Empty)
        {
            return BadRequest("Требуется указать корректный diseaseId.");
        }

        var doctors = await _doctorService.GetDoctorsByDiseaseIdAsync(diseaseId);

        if (doctors == null || !doctors.Any())
        {
            return NotFound($"Доктора по болезни с ID {diseaseId} не найдены.");
        }

        return Ok(doctors);
    }
    [HttpGet]
    public async Task<ActionResult<IEnumerable<DoctorDTO>>> GetAllDoctors()
    {
        var doctors = await _doctorService.GetAllDoctorsAsync();
        return Ok(doctors);
    }

}
