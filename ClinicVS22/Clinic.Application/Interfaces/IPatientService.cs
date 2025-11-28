using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clinic.Application.DTOs;

namespace Clinic.Application.Interfaces;

public interface IPatientService
{
    Task CreateAsync(PatientDTO patientDTO);
    Task DeleteAsync(Guid id);
    Task<List<PatientDTO>> GetAllWithFiltersAsync(string? title = null, Guid? diseaseId = null);
    Task<PatientDTO> getByIdAsync(Guid id);
    Task UpdateAsync(Guid id, PatientDTO patientDTO);

    Task<IEnumerable<PatientDTO>> GetAllPatientsAsync();
    Task<PatientDTO> GetPatientByIdAsync(Guid id);
    Task UpdatePatientAsync(Guid id, PatientDTO patientDTO);
}
