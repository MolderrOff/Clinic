using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clinic.Domain.Abstractions;
using Clinic.Domain.ValueObjects;

namespace Clinic.Domain.Entities;

public class Doctor : Entity<Guid>
{
    private Doctor() : base() { }
    private Doctor(Guid id, FullName fullName) : base(id)
    {
        FullName = fullName ?? throw new ArgumentNullException(nameof(fullName));
    }
    public FullName FullName { get; set; }
    public virtual List<Disease> Diseases { get; set; } = new List<Disease>();
    public static Doctor Create(
        Guid id
        , FullName fullName
        )
    {
        return new Doctor(
            id
            ,fullName  
            );
    }
}
