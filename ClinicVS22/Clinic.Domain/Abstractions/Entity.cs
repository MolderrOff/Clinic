using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Domain.Abstractions;

public abstract class Entity<TId> : IEquatable<Entity<TId>>
    where TId : notnull
{
    public TId Id { get; protected set; }
    protected Entity(TId id) => Id = id;
    protected Entity() { }
    public override bool Equals(object? obj) 
        => obj is Entity<TId> entity && Equals(entity.Id);
    public bool Equals(Entity<TId>? other)
        => Equals((object?)other);
    public override int GetHashCode() 
        => Id.GetHashCode();

    public static bool operator ==(Entity<TId>? left, Entity<TId>? right)
        => Equals(left, right);
    public static bool operator !=(Entity<TId>? left, Entity<TId?> right)
        => !Equals(left, right);
}
