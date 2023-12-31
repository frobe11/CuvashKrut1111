using Itmo.ObjectOrientedProgramming.Lab2.Components.MicroComponents.MotherboardFormFactor;

namespace Itmo.ObjectOrientedProgramming.Lab2.Components;

public interface IComponentWithMotherboardFormFactor
{
    IMotherBoardFormFactor MotherBoardFormFactor { get; }
}