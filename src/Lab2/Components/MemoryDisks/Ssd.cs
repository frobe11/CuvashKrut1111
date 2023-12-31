using System;
using Itmo.ObjectOrientedProgramming.Lab2.Components.MemoryDisks.Builder;
using Itmo.ObjectOrientedProgramming.Lab2.Components.MicroComponents;
using Itmo.ObjectOrientedProgramming.Lab2.Components.Results;

namespace Itmo.ObjectOrientedProgramming.Lab2.Components.MemoryDisks;

public class Ssd : IMemoryDisk, IDirector<ISsdBuilder>
{
    public Ssd(int capacity, int power, MemoryDiskConnectionOption connectionOption, int maxSpeed)
    {
        Capacity = capacity;
        Power = power;
        ConnectionOption = connectionOption;
        MaxSpeed = maxSpeed;
    }

    public int Power { get; }
    public MemoryDiskConnectionOption ConnectionOption { get; }
    public int MaxSpeed { get; }
    public int Capacity { get; }

    public CheckCompatibilityResult СheckСompatibility(IComponent component)
    {
        return new CheckCompatibilityResult.Сompatible();
    }

    public ISsdBuilder Direct(ISsdBuilder builder)
    {
        return builder.WithCapacity(Capacity)
            .WithPower(Power)
            .WithMaxSpeed(MaxSpeed)
            .WithConnectionOption(ConnectionOption);
    }

    public override bool Equals(object? obj)
    {
        if (obj is null) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((Ssd)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Power, (int)ConnectionOption, MaxSpeed, Capacity);
    }

    public bool Equals(IComponent? other)
    {
        return Equals(this, (object?)other);
    }

    protected bool Equals(Ssd other)
    {
        return Power == other.Power && ConnectionOption == other.ConnectionOption && MaxSpeed == other.MaxSpeed && Capacity == other.Capacity;
    }
}