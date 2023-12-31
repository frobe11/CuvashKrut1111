using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Components.MicroComponents.Dimensions;
using Itmo.ObjectOrientedProgramming.Lab2.Components.MicroComponents.Socket;

namespace Itmo.ObjectOrientedProgramming.Lab2.Components.CpuCooler.Builder;

public class CpuCoolerBuilder : ICpuCoolerBuilder
{
    private IEnumerable<ISocket>? _sockets;
    private IDimension? _dimension;
    private double _tdp;
    public ICpuCoolerBuilder WithSupportedSockets(IEnumerable<ISocket> sockets)
    {
        _sockets = sockets;
        return this;
    }

    public ICpuCoolerBuilder WithDimension(IDimension dimension)
    {
        _dimension = dimension;
        return this;
    }

    public ICpuCoolerBuilder WithTdp(double tdp)
    {
        _tdp = tdp;
        return this;
    }

    public ICpuCooler Build()
    {
        return new CpuCooler(
            _sockets ?? throw new ArgumentNullException(nameof(_sockets)),
            _tdp,
            _dimension ?? throw new ArgumentNullException(nameof(_dimension)));
    }
}