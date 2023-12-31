﻿using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Components.Xmp.Builder;

public class XmpBuilder : IXmpBuilder
{
    private string? _timings;
    private int _voltage;
    private int _frequency;
    public IXmpBuilder WithTimings(string timings)
    {
        _timings = timings;
        return this;
    }

    public IXmpBuilder WithVoltage(int voltage)
    {
        _voltage = voltage;
        return this;
    }

    public IXmpBuilder WithFrequency(int frequency)
    {
        _frequency = frequency;
        return this;
    }

    public IXmp Build()
    {
        return new Xmp(
            _timings ?? throw new ArgumentNullException(nameof(_timings)),
            _frequency,
            _voltage);
    }
}