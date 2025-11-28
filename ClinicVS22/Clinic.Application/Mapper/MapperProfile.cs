using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Clinic.Application.DTOs;
using Clinic.Domain.Entities;
using Clinic.Domain.ValueObjects;

namespace Clinic.Application.Mapper;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<Doctor, DoctorDTO>().ReverseMap();

        CreateMap<Doctor, DoctorDTO>()
            .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.FullName))
            .ReverseMap();

        CreateMap<Patient, PatientDTO>()
         .ForMember(dest => dest.PatientName, opt => opt.MapFrom(src => src.FullName))
         .ReverseMap()
         .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.PatientName));

        CreateMap<PatientDTO, Patient>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.PatientName)); ;

        CreateMap<FullName, FullNameDTO>().ReverseMap();
        
        CreateMap<Disease, DiseaseDTO>().ReverseMap();
    }
}
