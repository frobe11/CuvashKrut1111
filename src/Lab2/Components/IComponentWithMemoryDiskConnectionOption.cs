using Itmo.ObjectOrientedProgramming.Lab2.Components.MicroComponents;

namespace Itmo.ObjectOrientedProgramming.Lab2.Components;

public interface IComponentWithMemoryDiskConnectionOption
{
    MemoryDiskConnectionOption ConnectionOption { get; }
}