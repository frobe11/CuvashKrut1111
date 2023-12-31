using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Components.Processor;

namespace Itmo.ObjectOrientedProgramming.Lab2.Components;

public interface IComponentWithSupportedProcessors
{
    IEnumerable<IProcessor> SupportedProcessors { get; }
}