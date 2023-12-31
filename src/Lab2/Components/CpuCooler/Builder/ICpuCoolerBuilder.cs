using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Components.MicroComponents.Dimensions;
using Itmo.ObjectOrientedProgramming.Lab2.Components.MicroComponents.Socket;

namespace Itmo.ObjectOrientedProgramming.Lab2.Components.CpuCooler.Builder;

public interface ICpuCoolerBuilder
{
    ICpuCoolerBuilder WithSupportedSockets(IEnumerable<ISocket> sockets);
    ICpuCoolerBuilder WithDimension(IDimension dimension);
    ICpuCoolerBuilder WithTdp(double tdp);
    ICpuCooler Build();
}