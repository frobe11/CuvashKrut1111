using Itmo.ObjectOrientedProgramming.Lab2.Components.MicroComponents.Chipset;

namespace Itmo.ObjectOrientedProgramming.Lab2.Components;

public interface IComponentWithChipset
{
    IChipset Chipset { get; }
}