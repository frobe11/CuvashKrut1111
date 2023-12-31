namespace Itmo.ObjectOrientedProgramming.Lab2.Components.Ram;

public interface IRam
    : IComponent,
    IComponentWithSupportedMemoryFrequencies,
    IComponentWithPower,
    IComponentWithDdrStandard,
    IComponentWithIRamFormFactor,
    IComponentWithSupportedXmpProfiles
{ }