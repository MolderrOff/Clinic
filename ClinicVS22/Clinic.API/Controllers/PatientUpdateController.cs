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
[Route("api/patient-update")]
public class PatientUpdateController : ControllerBase
{
    private readonly IPatientService _patientService;
    public PatientUpdateController(IPatientService patientService)
    {
        _patientService = patientService;
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdatePatient(Guid id, [FromBody] PatientDTO patientDTO)
    {
        try
        {
            await _patientService.UpdatePatientAsync(id, patientDTO);
            return Ok($"Пациент с ID {id} успешно обновлен.");
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine(ex.InnerException?.Message ?? ex.Message);
            return BadRequest("Ошибка при обновлении данных. Проверьте отправленные данные или их корректность.");
        }
    }
}
