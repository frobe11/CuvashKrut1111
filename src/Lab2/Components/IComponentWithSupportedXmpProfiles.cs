using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Components.Xmp;

namespace Itmo.ObjectOrientedProgramming.Lab2.Components;

public interface IComponentWithSupportedXmpProfiles
{
    IEnumerable<IXmp> XmpProfiles { get; }
}