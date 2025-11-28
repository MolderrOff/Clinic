using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clinic.Domain.Entities;
using Clinic.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Clinic.Infrastructure.Persistens.Repositories;

public class DiseaseRepository : IDiseaseRepository
{
    private readonly ApplicationDbContext _dbContext;
    public DiseaseRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task AddAsync(Disease disease)
    {
        await _dbContext.AddAsync(disease);
    }
    public async Task<IEnumerable<Disease>> GetAllAsync()
    {
        return await _dbContext.Diseases.ToListAsync();
    }
}
