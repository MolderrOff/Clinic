using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Clinic.Application.DTOs;
using Clinic.Application.Interfaces;
using Clinic.Domain.Interfaces;

namespace Clinic.Application.Services;

public class DiseaseService : IDiseaseService
{
    private readonly IDiseaseRepository _diseaseRepository;
    private readonly IMapper _mapper;
    public DiseaseService(IDiseaseRepository diseaseRepository, IMapper mapper)
    {
        _diseaseRepository = diseaseRepository;
        _mapper = mapper;
    }
    public Task CreateAsync(DiseaseDTO disease)
    {
        throw new NotImplementedException();
    }

    public Task<List<DiseaseDTO>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(DiseaseDTO disease)
    {
        throw new NotImplementedException();
    }
    public async Task<IEnumerable<DiseaseDTO>> GetAllDiseasesAsync()
    {
        var diseases = await _diseaseRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<DiseaseDTO>>(diseases);
    }
}

