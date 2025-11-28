using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Clinic.Domain.Entities;
using Clinic.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Clinic.Infrastructure.Persistens.Repositories;

public class PatientRepository : IPatientRepository
{
    private readonly ApplicationDbContext _dbContext;
    private readonly IMapper _mapper;
    public PatientRepository(ApplicationDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper; 
    }
    public async Task AddPatientAsyncD(Patient patient)
    {
        await _dbContext.Patients.AddAsync(patient);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<Patient>> GetAllAsync()
    {
        return await _dbContext.Patients
            .Include(p => p.FullName)
            .ToListAsync();
    }

    public Task<IEnumerable<Patient>> GetAllPatientAsyncD()
    {
        throw new NotImplementedException();
    }

    public async Task<Patient?> GetByIdAsync(Guid id)
    {
        return await _dbContext.Patients
            .Include(p => p.FullName)
            .FirstOrDefaultAsync(p => p.Id == id);
            
    }

    public async Task UpdateAsync(Patient patient)
    {
        //return Task.CompletedTask;
        _dbContext.Patients.Update(patient);
        await _dbContext.SaveChangesAsync();
    }

    public void UpdatePatientAsyncD(Patient patient)
    {
        throw new NotImplementedException();
    }
}
