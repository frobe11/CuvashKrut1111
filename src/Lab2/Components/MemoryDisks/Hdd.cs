using System;
using Itmo.ObjectOrientedProgramming.Lab2.Components.MemoryDisks.Builder;
using Itmo.ObjectOrientedProgramming.Lab2.Components.MicroComponents;
using Itmo.ObjectOrientedProgramming.Lab2.Components.Results;

namespace Itmo.ObjectOrientedProgramming.Lab2.Components.MemoryDisks;

public class Hdd : IMemoryDisk, IDirector<IHddBuilder>
{
    public Hdd(int power, int rotationSpeed, int capacity)
    {
        Power = power;
        RotationSpeed = rotationSpeed;
        Capacity = capacity;
        ConnectionOption = MemoryDiskConnectionOption.Sata;
    }

    public int Power { get; }
    public MemoryDiskConnectionOption ConnectionOption { get; }
    public int RotationSpeed { get; }
    public int Capacity { get; }

    public CheckCompatibilityResult СheckСompatibility(IComponent component)
    {
        return new CheckCompatibilityResult.Сompatible();
    }

    public IHddBuilder Direct(IHddBuilder builder)
    {
        return builder.WithCapacity(Capacity)
            .WithPower(Power)
            .WithRotationSpeed(RotationSpeed);
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
        return Equals((Hdd)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Power, (int)ConnectionOption, RotationSpeed, Capacity);
    }

    protected bool Equals(Hdd other)
    {
        return Power == other.Power && ConnectionOption == other.ConnectionOption && RotationSpeed == other.RotationSpeed && Capacity == other.Capacity;
    }
}