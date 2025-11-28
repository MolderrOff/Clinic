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

public class DoctorService : IDoctorService
{
    private readonly IDoctorRepository _doctorRepository;
    private readonly IMapper _mapper;
    public DoctorService(IDoctorRepository doctorRepository, IMapper mapper)
    {
        _doctorRepository = doctorRepository;
        _mapper = mapper;
    }
    public Task CreateAsync(DoctorDTO doctorDTO)
    {
        throw new NotImplementedException();
    }

    public Task<List<DoctorDTO>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(DoctorDTO doctorDTO)
    {
        throw new NotImplementedException();
    }
    public async Task<IEnumerable<DoctorDTO>> GetDoctorsBySpecializationAsync(string specialization)
    {
        var doctors = await _doctorRepository.GetBySpecializationAsync(specialization);
        return _mapper.Map<IEnumerable<DoctorDTO>>(doctors);


    }

    public async Task<IEnumerable<DoctorDTO>> GetDoctorsByDiseaseIdAsync(Guid diseaseId)
    {
        var doctors = await _doctorRepository.GetByDiseaseIdAsync(diseaseId);
        return _mapper.Map<IEnumerable<DoctorDTO>>(doctors);
    }
        public async Task<IEnumerable<DoctorDTO>> GetAllDoctorsAsync()
    {
        var doctors = await _doctorRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<DoctorDTO>>(doctors);
    }
}
