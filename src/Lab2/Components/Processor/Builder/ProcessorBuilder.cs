using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Components.MicroComponents.Socket;

namespace Itmo.ObjectOrientedProgramming.Lab2.Components.Processor.Builder;

public class ProcessorBuilder : IProcessorBuilder
{
    private int _coreFrequency;
    private int _coreNumber;
    private ISocket? _socket;
    private bool _withVideoCore;
    private IEnumerable<int>? _supportedMemoryFrequencies;
    private double _tdp;
    private int _power;
    public IProcessorBuilder WithCoreFrequency(int coreFrequency)
    {
        _coreFrequency = coreFrequency;
        return this;
    }

    public IProcessorBuilder WithCoreNumber(int number)
    {
        _coreNumber = number;
        return this;
    }

    public IProcessorBuilder WithSocket(ISocket socket)
    {
        _socket = socket;
        return this;
    }

    public IProcessorBuilder WithVideoCore(bool withVideoCore)
    {
        _withVideoCore = withVideoCore;
        return this;
    }

    public IProcessorBuilder WithSupportedMemoryFrequencies(IEnumerable<int> frequencies)
    {
        _supportedMemoryFrequencies = frequencies;
        return this;
    }

    public IProcessorBuilder WithTpd(double tdp)
    {
        _tdp = tdp;
        return this;
    }

    public IProcessorBuilder WithPower(int power)
    {
        _power = power;
        return this;
    }

    public IProcessor Build()
    {
        return new Processor(
            _socket ?? throw new ArgumentNullException(nameof(_socket)),
            _supportedMemoryFrequencies ?? throw new ArgumentNullException(nameof(_supportedMemoryFrequencies)),
            _coreFrequency,
            _coreNumber,
            _tdp,
            _withVideoCore,
            _power);
    }
}