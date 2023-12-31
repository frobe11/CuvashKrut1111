using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Components.Processor;

namespace Itmo.ObjectOrientedProgramming.Lab2.Components.Bios.Builder;

public class BiosBuilder : IBiosBuilder
{
    private string? _type;
    private string? _version;
    private IEnumerable<IProcessor>? _processors;
    public IBiosBuilder WithType(string type)
    {
        _type = type;
        return this;
    }

    public IBiosBuilder WithVersion(string version)
    {
        _version = version;
        return this;
    }

    public IBiosBuilder WithSupportedProcessors(IEnumerable<IProcessor> processors)
    {
        _processors = processors;
        return this;
    }

    public IBios Build()
    {
        return new Bios(
            _processors ?? throw new ArgumentNullException(nameof(_processors)),
            _type ?? throw new ArgumentNullException(nameof(_type)),
            _version ?? throw new ArgumentNullException(nameof(_version)));
    }
}