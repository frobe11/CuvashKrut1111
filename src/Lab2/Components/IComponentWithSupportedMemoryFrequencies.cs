using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.Components;

public interface IComponentWithSupportedMemoryFrequencies
{
    IEnumerable<int> SupportedMemoryFrequencies { get; }
}