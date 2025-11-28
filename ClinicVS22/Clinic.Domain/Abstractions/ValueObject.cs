using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Domain.Abstractions;

public abstract class ValueObject : IEquatable<ValueObject>
{
    protected abstract IEnumerable<object> GetEqualityComponents();
    public override bool Equals(object? obj)
    {
        if (obj == null || obj.GetType() != GetType())
            return false;
        var other =(ValueObject)obj;
        return GetEqualityComponents().SequenceEqual(other.GetEqualityComponents());
        
    }

    public bool Equals(ValueObject? other)
        => Equals((object?)other);

    public override int GetHashCode()
        => GetEqualityComponents()
        .Select(x => x.GetHashCode())
        .Aggregate((x, y) => 2* x^y);
    public static bool operator ==(ValueObject? left, ValueObject? right)
        => Equals(left, right);
    public static bool operator !=(ValueObject? left, ValueObject? right)
        => !Equals(left, right);
}
