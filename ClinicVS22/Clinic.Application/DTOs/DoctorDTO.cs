using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clinic.Domain.Entities;
using Clinic.Domain.ValueObjects;

namespace Clinic.Application.DTOs;

public class DoctorDTO
{
    public DoctorDTO() { }
    public Guid Id { get; set; }
    public FullName FullName { get; set; }
    public Disease Disease { get; set; }
    public List<DiseaseDTO> Diseases { get; set; } = new List<DiseaseDTO>();
}
