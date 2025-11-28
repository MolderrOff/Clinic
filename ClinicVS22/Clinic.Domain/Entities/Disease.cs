using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clinic.Domain.Abstractions;

namespace Clinic.Domain.Entities;

//Product
public class Disease : Entity<Guid>
{
    public Disease() : base() { }
    private Disease(
        Guid id,
        string name
        ) : base(id)
    {
        Name = name;
    }
    public string Name { get; private set; }
    public virtual  List<Patient>? Patients { get; private set; }
   

    public static Disease Create(Guid id,string name)
    {
        if(string.IsNullOrWhiteSpace(name))
            throw new ArgumentNullException("Name can not be null or empty. Message of domain");
        return new Disease(id, name);
    }
}
