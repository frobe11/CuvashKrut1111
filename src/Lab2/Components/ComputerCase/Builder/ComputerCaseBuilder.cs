using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Components.MicroComponents.Dimensions;
using Itmo.ObjectOrientedProgramming.Lab2.Components.MicroComponents.MotherboardFormFactor;

namespace Itmo.ObjectOrientedProgramming.Lab2.Components.ComputerCase.Builder;

public class ComputerCaseBuilder : IComputerCaseBuilder
{
    private int _height;
    private int _width;
    private IEnumerable<IMotherBoardFormFactor>? _supportedMotherBoardFormFactors;
    private IDimension? _dimension;
    public IComputerCaseBuilder WithMaxVideoCardSize(int height, int width)
    {
        _height = height;
        _width = width;
        return this;
    }

    public IComputerCaseBuilder WithSupportedMotherboardFormFactor(IEnumerable<IMotherBoardFormFactor> supportedMotherBoardFormFactors)
    {
        _supportedMotherBoardFormFactors = supportedMotherBoardFormFactors;
        return this;
    }

    public IComputerCaseBuilder WithDimension(IDimension dimension)
    {
        _dimension = dimension;
        return this;
    }

    public IComputerCase Build()
    {
        return new ComputerCase(
            _height,
            _width,
            _supportedMotherBoardFormFactors ?? throw new ArgumentNullException(nameof(_supportedMotherBoardFormFactors)),
            _dimension ?? throw new ArgumentNullException(nameof(_dimension)));
    }
}