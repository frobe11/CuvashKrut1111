using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Components.MicroComponents.Dimensions;
using Itmo.ObjectOrientedProgramming.Lab2.Components.MicroComponents.MotherboardFormFactor;

namespace Itmo.ObjectOrientedProgramming.Lab2.Components.ComputerCase.Builder;

public interface IComputerCaseBuilder
{
    IComputerCaseBuilder WithMaxVideoCardSize(int height, int width);
    IComputerCaseBuilder WithSupportedMotherboardFormFactor(IEnumerable<IMotherBoardFormFactor> supportedMotherBoardFormFactors);
    IComputerCaseBuilder WithDimension(IDimension dimension);
    IComputerCase Build();
}