using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Components.Xmp;

namespace Itmo.ObjectOrientedProgramming.Lab2.Components.MicroComponents.Chipset;

public class Chipset : IChipset
{
    public Chipset(IEnumerable<int> supportedMemoryFrequencies, IEnumerable<IXmp> xmpProfiles)
    {
        SupportedMemoryFrequencies = supportedMemoryFrequencies;
        XmpProfiles = xmpProfiles;
    }

    public IEnumerable<int> SupportedMemoryFrequencies { get; }
    public IEnumerable<IXmp> XmpProfiles { get; }
}