using System;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Components.Results;
using Itmo.ObjectOrientedProgramming.Lab2.Components.Xmp.Builder;

namespace Itmo.ObjectOrientedProgramming.Lab2.Components.Xmp;

public class Xmp : IXmp, IDirector<IXmpBuilder>
{
    public Xmp(string timings, int frequency, int voltage)
    {
        Timings = timings;
        Frequency = frequency;
        Voltage = voltage;
    }

    public string Timings { get; }
    public int Frequency { get; }
    public int Voltage { get; }

    public CheckCompatibilityResult СheckСompatibility(IComponent component)
    {
        if (component is not IComponentWithSupportedXmpProfiles componentWithSupportedXmpProfiles)
            return new CheckCompatibilityResult.Сompatible();
        if (componentWithSupportedXmpProfiles.XmpProfiles.All(x => !x.Equals(this)))
            return new CheckCompatibilityResult.NotСompatible(this, component);

        return new CheckCompatibilityResult.Сompatible();
    }

    public IXmpBuilder Direct(IXmpBuilder builder)
    {
        return builder.WithFrequency(Frequency)
            .WithTimings(Timings)
            .WithVoltage(Voltage);
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
        return Equals((Xmp)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Timings, Frequency, Voltage);
    }

    protected bool Equals(Xmp other)
    {
        return Timings == other.Timings && Frequency == other.Frequency && Voltage == other.Voltage;
    }
}