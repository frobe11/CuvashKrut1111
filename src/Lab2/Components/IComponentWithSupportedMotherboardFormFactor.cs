using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Components.MicroComponents.MotherboardFormFactor;

namespace Itmo.ObjectOrientedProgramming.Lab2.Components;

public interface IComponentWithSupportedMotherboardFormFactor
{
    IEnumerable<IMotherBoardFormFactor> SupportedMotherboardFormFactor { get; }
}