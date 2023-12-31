namespace Itmo.ObjectOrientedProgramming.Lab2.Components.Processor;

public interface IProcessor
    : IComponent,
        IComponentWithSocket,
        IComponentWithTdp,
        IComponentWithSupportedMemoryFrequencies,
        IComponentWithVideoCore,
        IComponentWithPower
{ }