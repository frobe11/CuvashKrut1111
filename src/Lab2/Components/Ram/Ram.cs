using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Components.MicroComponents.RamFormFactor;
using Itmo.ObjectOrientedProgramming.Lab2.Components.Ram.Builder;
using Itmo.ObjectOrientedProgramming.Lab2.Components.Results;
using Itmo.ObjectOrientedProgramming.Lab2.Components.Xmp;

namespace Itmo.ObjectOrientedProgramming.Lab2.Components.Ram;

public class Ram : IRam, IDirector<IRamBuilder>
{
    public Ram(IRamFormFactor ramFormFactor, IEnumerable<int> supportedMemoryFrequencies, IEnumerable<IXmp> xmpProfiles, int power, int ddrStandard, int capacity)
    {
        RamFormFactor = ramFormFactor;
        SupportedMemoryFrequencies = supportedMemoryFrequencies;
        XmpProfiles = xmpProfiles;
        Power = power;
        DdrStandard = ddrStandard;
        Capacity = capacity;
    }

    public IEnumerable<int> SupportedMemoryFrequencies { get; }
    public int Power { get; }
    public int DdrStandard { get; }
    public int Capacity { get; }
    public IRamFormFactor RamFormFactor { get; }
    public IEnumerable<IXmp> XmpProfiles { get; }
    public CheckCompatibilityResult СheckСompatibility(IComponent component)
    {
        if (component is not IComponentWithSupportedMemoryFrequencies componentWithSupportedMemoryFrequencies)
            return new CheckCompatibilityResult.Сompatible();
        bool match = false;
        foreach (int memory1 in SupportedMemoryFrequencies)
        {
            foreach (int memory2 in componentWithSupportedMemoryFrequencies.SupportedMemoryFrequencies)
            {
                if (memory1 == memory2) match = true;
            }
        }

        if (!match) return new CheckCompatibilityResult.NotСompatible(this, component);

        return new CheckCompatibilityResult.Сompatible();
    }

    public IRamBuilder Direct(IRamBuilder builder)
    {
        return builder.WithCapacity(Capacity)
            .WithDdrStandard(DdrStandard)
            .WithRamFormFactor(RamFormFactor)
            .WithSupportedMemoryFrequencies(SupportedMemoryFrequencies)
            .WithSupportedXmpProfiles(XmpProfiles)
            .WithPower(Power);
    }

    public bool Equals(IComponent? other)
    {
        return Equals(this, (object?)other);
    }

    public override bool Equals(object? obj)
    {
        if (obj is null) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((Ram)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(SupportedMemoryFrequencies, Power, DdrStandard, Capacity, RamFormFactor, XmpProfiles);
    }

    protected bool Equals(Ram other)
    {
        return SupportedMemoryFrequencies.Equals(other.SupportedMemoryFrequencies) && Power == other.Power && DdrStandard == other.DdrStandard && Capacity == other.Capacity && RamFormFactor.Equals(other.RamFormFactor) && XmpProfiles.Equals(other.XmpProfiles);
    }
}