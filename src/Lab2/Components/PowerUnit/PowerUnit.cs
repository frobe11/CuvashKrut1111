using Itmo.ObjectOrientedProgramming.Lab2.Components.Results;

namespace Itmo.ObjectOrientedProgramming.Lab2.Components.PowerUnit;

public class PowerUnit : IPowerUnit
{
    public PowerUnit(int power)
    {
        Power = power;
    }

    public int Power { get; }

    public CheckCompatibilityResult СheckСompatibility(IComponent component)
    {
        return new CheckCompatibilityResult.Сompatible();
    }

    public bool Equals(IComponent? other)
    {
        return Equals(this, other);
    }

    public override bool Equals(object? obj)
    {
        if (obj is null) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((PowerUnit)obj);
    }

    public override int GetHashCode()
    {
        return Power;
    }

    protected bool Equals(PowerUnit other)
    {
        return Power == other.Power;
    }
}