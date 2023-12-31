namespace Itmo.ObjectOrientedProgramming.Lab2.Components.CpuCooler;

public interface ICpuCooler
    : IComponent,
        IComponentWithSupportedSockets,
        IComponentWithTdp
{ }