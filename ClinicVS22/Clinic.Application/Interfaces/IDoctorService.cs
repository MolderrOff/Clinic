using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clinic.Application.DTOs;

namespace Clinic.Application.Interfaces;

public interface IDoctorService
{
    Task CreateAsync(DoctorDTO doctorDTO);
    Task UpdateAsync(DoctorDTO doctorDTO);
    Task<List<DoctorDTO>> GetAllAsync();
    Task<IEnumerable<DoctorDTO>> GetDoctorsByDiseaseIdAsync(Guid diseaseId);
    Task<IEnumerable<DoctorDTO>> GetAllDoctorsAsync();
}
