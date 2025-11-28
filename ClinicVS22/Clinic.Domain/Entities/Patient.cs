using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clinic.Domain.Abstractions;
using Clinic.Domain.ValueObjects;

namespace Clinic.Domain.Entities;

//Category
public class Patient : Entity<Guid>
{
    public Patient() : base() { } 
    public Patient( 
        Guid id,
        FullName fullName,
        Guid diseaseId,
        string address
        ) : base(id)
    {
        FullName = fullName;
        DiseaseId = diseaseId;
        Address = address;
    }
    public FullName FullName { get; set; }
    public Disease Disease { get; set; } 
    public Guid DiseaseId { get; set; }
    public string Address { get; set; }
    public static Patient Create(Guid id, FullName fullName, Guid diseaseId, string address) 
    {
        return new Patient(id, fullName, diseaseId, address); 
    }

}
