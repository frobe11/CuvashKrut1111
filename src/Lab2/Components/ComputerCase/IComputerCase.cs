using Itmo.ObjectOrientedProgramming.Lab2.Components.MicroComponents;

namespace Itmo.ObjectOrientedProgramming.Lab2.Components.ComputerCase;

public interface IComputerCase
    : IComponent,
    ISizeComparer,
    IComponentWithSupportedMotherboardFormFactor
{ }