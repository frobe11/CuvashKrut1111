using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Components.MicroComponents.RamFormFactor;
using Itmo.ObjectOrientedProgramming.Lab2.Components.Xmp;

namespace Itmo.ObjectOrientedProgramming.Lab2.Components.Ram.Builder;

public interface IRamBuilder
{
    IRamBuilder WithCapacity(int capacity);
    IRamBuilder WithSupportedMemoryFrequencies(IEnumerable<int> supportedMemoryFrequencies);
    IRamBuilder WithSupportedXmpProfiles(IEnumerable<IXmp> xmpProfiles);
    IRamBuilder WithRamFormFactor(IRamFormFactor ramFormFactor);
    IRamBuilder WithDdrStandard(int standard);
    IRamBuilder WithPower(int power);
    IRam Build();
}