using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Components.MicroComponents.RamFormFactor;
using Itmo.ObjectOrientedProgramming.Lab2.Components.Xmp;

namespace Itmo.ObjectOrientedProgramming.Lab2.Components.Ram.Builder;

public class RamBuilder : IRamBuilder
{
    private int _capacity;
    private IEnumerable<int>? _supportedMemoryFrequencies;
    private IEnumerable<IXmp>? _supportedXmpProfiles;
    private IRamFormFactor? _ramFormFactor;
    private int _ddrStandard;
    private int _power;
    public IRamBuilder WithCapacity(int capacity)
    {
        _capacity = capacity;
        return this;
    }

    public IRamBuilder WithSupportedMemoryFrequencies(IEnumerable<int> supportedMemoryFrequencies)
    {
        _supportedMemoryFrequencies = supportedMemoryFrequencies;
        return this;
    }

    public IRamBuilder WithSupportedXmpProfiles(IEnumerable<IXmp> xmpProfiles)
    {
        _supportedXmpProfiles = xmpProfiles;
        return this;
    }

    public IRamBuilder WithRamFormFactor(IRamFormFactor ramFormFactor)
    {
        _ramFormFactor = ramFormFactor;
        return this;
    }

    public IRamBuilder WithDdrStandard(int standard)
    {
        _ddrStandard = standard;
        return this;
    }

    public IRamBuilder WithPower(int power)
    {
        _power = power;
        return this;
    }

    public IRam Build()
    {
        return new Ram(
            _ramFormFactor ?? throw new ArgumentNullException(nameof(_ramFormFactor)),
            _supportedMemoryFrequencies ?? throw new ArgumentNullException(nameof(_supportedMemoryFrequencies)),
            _supportedXmpProfiles ?? throw new ArgumentNullException(nameof(_supportedXmpProfiles)),
            _power,
            _ddrStandard,
            _capacity);
    }
}