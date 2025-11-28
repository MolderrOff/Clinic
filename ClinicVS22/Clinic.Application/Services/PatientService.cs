using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Clinic.Application.DTOs;
using Clinic.Application.Interfaces;
using Clinic.Domain.Entities;
using Clinic.Domain.Interfaces;

namespace Clinic.Application.Services;

public class PatientService : IPatientService
{
   private readonly  IPatientRepository _patientRepository;
    
    private readonly IMapper _mapper;
    public PatientService(IPatientRepository patientRepository, IMapper mapper)
    {
        _mapper = mapper;
        _patientRepository = patientRepository;
    }
    public async Task CreateAsync(PatientDTO patientDTO)
    {
        var patientEntity = _mapper.Map<Patient>(patientDTO);


        await _patientRepository.AddPatientAsyncD(patientEntity);
        //было await _patientService.CreateAsync(patientDTO);
    }

    public Task DeleteAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<List<PatientDTO>> GetAllWithFiltersAsync(string? title = null, Guid? diseaseId = null)
    {
        throw new NotImplementedException();
    }

    public Task<PatientDTO> getByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(Guid id, PatientDTO patientDTO)
    {
        throw new NotImplementedException();
    }


    public async Task<IEnumerable<PatientDTO>> GetAllPatientsAsync()
    {
        var patients = await _patientRepository.GetAllAsync(); 
        return _mapper.Map<IEnumerable<PatientDTO>>(patients);
    }

    // Реализация вывода по ID
    public async Task<PatientDTO> GetPatientByIdAsync(Guid id)
    {
        var patient = await _patientRepository.GetByIdAsync(id);
        return _mapper.Map<PatientDTO>(patient);
    }

    public async Task UpdatePatientAsync(Guid id, PatientDTO patientDTO)
    {
        var existingPatient = await _patientRepository.GetByIdAsync(id);

        if (existingPatient == null)
        {
            throw new Exception("Patient not found");
        }


        _mapper.Map(patientDTO, existingPatient);


        await _patientRepository.UpdateAsync(existingPatient);

    }
}
