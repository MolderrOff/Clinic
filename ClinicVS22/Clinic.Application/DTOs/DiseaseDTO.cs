using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clinic.Domain.ValueObjects;

namespace Clinic.Application.DTOs;

public class DiseaseDTO
{
    public DiseaseDTO() { }
    public Guid Id { get; set; }
    public string Name {  get; set; }
}
