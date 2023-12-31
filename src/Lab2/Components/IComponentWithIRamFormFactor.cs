using Itmo.ObjectOrientedProgramming.Lab2.Components.MicroComponents.RamFormFactor;

namespace Itmo.ObjectOrientedProgramming.Lab2.Components;

public interface IComponentWithIRamFormFactor
{
    IRamFormFactor RamFormFactor { get; }
}