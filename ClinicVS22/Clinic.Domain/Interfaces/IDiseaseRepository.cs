using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clinic.Domain.Entities;

namespace Clinic.Domain.Interfaces;

public interface IDiseaseRepository
{
    Task AddAsync(Disease disease);
    Task<IEnumerable<Disease>> GetAllAsync();
}
