using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clinic.Domain.Entities;
using Clinic.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Clinic.Infrastructure.Persistens.Repositories;

public class DoctorRepository : IDoctorRepository
{
    private readonly ApplicationDbContext _dbContext;

    public DoctorRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<Doctor>> GetByDiseaseIdAsync(Guid diseaseId)
    {
        return await _dbContext.Doctors
            .Include(d => d.Diseases)
            .Include(d => d.FullName)
            .Where(d => d.Diseases.Any(dis => dis.Id == diseaseId)) 
            .ToListAsync();
    }


    Task<Doctor> IDoctorRepository.AddAsync(Doctor doctor)
    {
        throw new NotImplementedException();
    }

    void IDoctorRepository.Delete(Doctor doctor)
    {
        throw new NotImplementedException();
    }

    Task<IEnumerable<Doctor>> IDoctorRepository.GetAllWithFiltersAsync(string? title, Guid? diseaseId)
    {
        throw new NotImplementedException();
    }

    Task<Doctor?> IDoctorRepository.GetByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    Task<IEnumerable<Doctor>> IDoctorRepository.GetBySpecializationAsync(string specialization)
    {
        throw new NotImplementedException();
    }

    void IDoctorRepository.Update(Doctor doctor)
    {
        throw new NotImplementedException();
    }
    public async Task<IEnumerable<Doctor>> GetAllAsync()
    {
        return await _dbContext.Doctors
            .Include(d => d.FullName)
            .Include(d => d.Diseases)
            .ToListAsync();
    }


    public async Task<Doctor?> GetByIdAsync(Guid id)
    {
        return await _dbContext.Doctors
           .Include(d => d.FullName)
           .Include(d => d.Diseases)
           .FirstOrDefaultAsync(d => d.Id == id);
    }


}
