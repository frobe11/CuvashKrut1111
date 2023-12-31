namespace Itmo.ObjectOrientedProgramming.Lab2.Components.Motherboard;

public interface IMotherboard
    : IComponent,
        IComponentWithSocket,
        IComponentWithBios,
        IComponentWithRamSlots,
        IComponentWithSataPorts,
        IComponentWithPcieLine,
        IComponentWithChipset,
        IComponentWithMotherboardFormFactor,
        IComponentWithIRamFormFactor,
        IComponentWithDdrStandard
{ }