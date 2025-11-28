using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clinic.Domain.Abstractions;

namespace Clinic.Domain.ValueObjects;

public class FullName : ValueObject
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public FullName(
        string name,
        string surname)
    {
        Name = name;
        Surname = surname;
    }
    public FullName() { }
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Name;
        yield return Surname;
    }
}
