using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Components.Processor;

namespace Itmo.ObjectOrientedProgramming.Lab2.Components.Bios.Builder;

public interface IBiosBuilder
{
    IBiosBuilder WithType(string type);
    IBiosBuilder WithVersion(string version);
    IBiosBuilder WithSupportedProcessors(IEnumerable<IProcessor> processors);
    IBios Build();
}