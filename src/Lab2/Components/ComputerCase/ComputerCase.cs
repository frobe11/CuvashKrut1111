using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Components.ComputerCase.Builder;
using Itmo.ObjectOrientedProgramming.Lab2.Components.MicroComponents.Dimensions;
using Itmo.ObjectOrientedProgramming.Lab2.Components.MicroComponents.MotherboardFormFactor;
using Itmo.ObjectOrientedProgramming.Lab2.Components.Results;

namespace Itmo.ObjectOrientedProgramming.Lab2.Components.ComputerCase;

public class ComputerCase : IComputerCase, IDirector<IComputerCaseBuilder>
{
    private readonly int _height;

    private readonly int _width;

    public ComputerCase(int height, int width, IEnumerable<IMotherBoardFormFactor> supportedMotherboardFormFactor, IDimension dimension)
    {
        _height = height;
        _width = width;
        SupportedMotherboardFormFactor = supportedMotherboardFormFactor;
        Dimension = dimension;
    }

    public IEnumerable<IMotherBoardFormFactor> SupportedMotherboardFormFactor { get; }

    public IDimension Dimension { get; }

    public CheckCompatibilityResult СheckСompatibility(IComponent component)
    {
        return new CheckCompatibilityResult.Сompatible();
    }

    public bool CompareSizes(int height, int width)
    {
        return _height >= height & _width >= width;
    }

    public IComputerCaseBuilder Direct(IComputerCaseBuilder builder)
    {
        return builder.WithDimension(Dimension)
            .WithMaxVideoCardSize(_height, _width)
            .WithSupportedMotherboardFormFactor(SupportedMotherboardFormFactor);
    }

    public bool Equals(IComponent? other)
    {
        return Equals(this, (object?)other);
    }

    public override bool Equals(object? obj)
    {
        if (obj is null) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((ComputerCase)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(_height, _width, SupportedMotherboardFormFactor, Dimension);
    }

    protected bool Equals(ComputerCase other)
    {
        return _height == other._height && _width == other._width && SupportedMotherboardFormFactor.Equals(other.SupportedMotherboardFormFactor) && Dimension.Equals(other.Dimension);
    }
}