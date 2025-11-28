using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clinic.Application.DTOs;
using Clinic.Domain.Entities;

namespace Clinic.Application.Interfaces;

public interface IDiseaseService
{
    Task CreateAsync(DiseaseDTO disease);
    Task UpdateAsync(DiseaseDTO disease);
    Task<List<DiseaseDTO>> GetAllAsync();
    Task<IEnumerable<DiseaseDTO>> GetAllDiseasesAsync();
}
