using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clinic.Domain.Entities;
using Clinic.Domain.ValueObjects;

namespace Clinic.Application.DTOs;

public class PatientDTO
{
    public PatientDTO() { }
    public Guid Id { get; set; }
    public FullName PatientName { get; set; }
    public Guid DiseaseId { get; set; }
    public string Address { get; set; }
    
}
