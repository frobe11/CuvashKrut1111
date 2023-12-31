using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Components.CpuCooler.Builder;
using Itmo.ObjectOrientedProgramming.Lab2.Components.MicroComponents.Dimensions;
using Itmo.ObjectOrientedProgramming.Lab2.Components.MicroComponents.Socket;
using Itmo.ObjectOrientedProgramming.Lab2.Components.Results;

namespace Itmo.ObjectOrientedProgramming.Lab2.Components.CpuCooler;

public class CpuCooler : ICpuCooler, IDirector<ICpuCoolerBuilder>
{
    public CpuCooler(IEnumerable<ISocket> supportedSockets, double tdp, IDimension dimension)
    {
        SupportedSockets = supportedSockets;
        Tdp = tdp;
        Dimension = dimension;
    }

    public IDimension Dimension { get; }
    public IEnumerable<ISocket> SupportedSockets { get; }
    public double Tdp { get; }
    public CheckCompatibilityResult СheckСompatibility(IComponent component)
    {
        return new CheckCompatibilityResult.Сompatible();
    }

    public ICpuCoolerBuilder Direct(ICpuCoolerBuilder builder)
    {
        return builder.WithSupportedSockets(SupportedSockets)
            .WithDimension(Dimension)
            .WithTdp(Tdp);
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
        return Equals((CpuCooler)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Dimension, SupportedSockets, Tdp);
    }

    protected bool Equals(CpuCooler other)
    {
        return Dimension.Equals(other.Dimension) && SupportedSockets.Equals(other.SupportedSockets) && Tdp.Equals(other.Tdp);
    }
}