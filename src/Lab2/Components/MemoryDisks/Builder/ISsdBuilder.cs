using Itmo.ObjectOrientedProgramming.Lab2.Components.MicroComponents;

namespace Itmo.ObjectOrientedProgramming.Lab2.Components.MemoryDisks.Builder;

public interface ISsdBuilder
{
    ISsdBuilder WithCapacity(int capacity);
    ISsdBuilder WithConnectionOption(MemoryDiskConnectionOption connectionOption);
    ISsdBuilder WithMaxSpeed(int speed);
    ISsdBuilder WithPower(int power);
    IMemoryDisk Build();
}