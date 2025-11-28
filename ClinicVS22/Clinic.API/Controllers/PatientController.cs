using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Clinic.Application.DTOs;
using Clinic.Application.Interfaces;
using Clinic.Domain.Entities;
using Clinic.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Clinic.API.Controllers;

[ApiController]
[Route("api/patients")]
public class PatientController : ControllerBase
{
    private readonly IPatientService _patientService;
    
    public PatientController(IPatientService patientService) 
    {
        _patientService = patientService;
      
    }

    [HttpPost]
    public async Task<ActionResult> Create([FromBody] PatientDTO patientDTO)
    {
        await _patientService.CreateAsync(patientDTO);
        return Ok("Patient created successfully");
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<PatientDTO>>> GetAllPatients()
    {
        var patients = await _patientService.GetAllPatientsAsync();
        return Ok(patients);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<PatientDTO>> GetPatientById(Guid id)
    {
        var patient = await _patientService.GetPatientByIdAsync(id);

        if (patient == null)
        {
            return NotFound($"Пациент с ID {id} не найден.");
        }

        return Ok(patient);
    }


}
