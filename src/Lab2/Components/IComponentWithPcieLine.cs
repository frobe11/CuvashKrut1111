using Itmo.ObjectOrientedProgramming.Lab2.Components.MicroComponents.PcieLine;

namespace Itmo.ObjectOrientedProgramming.Lab2.Components;

public interface IComponentWithPcieLine
{
    IPcieLine PcieLine { get; }
}