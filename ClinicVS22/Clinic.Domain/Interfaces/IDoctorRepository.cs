using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clinic.Domain.Entities;

namespace Clinic.Domain.Interfaces;

public interface IDoctorRepository
{
    public Task<IEnumerable<Doctor>> GetAllWithFiltersAsync(string? title = null, Guid? diseaseId = null);
    public Task<Doctor?> GetByIdAsync(Guid id);
    public Task<Doctor> AddAsync(Doctor doctor);
    public void Update(Doctor doctor);
    public void Delete(Doctor doctor);
    Task<IEnumerable<Doctor>> GetBySpecializationAsync(string specialization);
    Task<IEnumerable<Doctor>> GetByDiseaseIdAsync(Guid diseaseId);
    
    Task<IEnumerable<Doctor>> GetAllAsync();
}
