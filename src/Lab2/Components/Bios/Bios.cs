using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Components.Bios.Builder;
using Itmo.ObjectOrientedProgramming.Lab2.Components.Processor;
using Itmo.ObjectOrientedProgramming.Lab2.Components.Results;

namespace Itmo.ObjectOrientedProgramming.Lab2.Components.Bios;

public class Bios : IBios, IDirector<IBiosBuilder>
{
    public Bios(IEnumerable<IProcessor> supportedProcessors, string type, string version)
    {
        SupportedProcessors = supportedProcessors;
        Type = type;
        Version = version;
    }

    public IEnumerable<IProcessor> SupportedProcessors { get; }

    public string Type { get; }

    public string Version { get; }

    public CheckCompatibilityResult СheckСompatibility(IComponent component)
    {
        return new CheckCompatibilityResult.Сompatible();
    }

    public IBiosBuilder Direct(IBiosBuilder builder)
    {
        return builder.WithType(Type)
            .WithSupportedProcessors(SupportedProcessors)
            .WithVersion(Version);
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
        return Equals((Bios)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(SupportedProcessors, Type, Version);
    }

    protected bool Equals(Bios other)
    {
        return SupportedProcessors.Equals(other.SupportedProcessors) && Type == other.Type && Version == other.Version;
    }
}