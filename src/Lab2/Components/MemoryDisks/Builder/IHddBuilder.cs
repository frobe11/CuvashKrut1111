namespace Itmo.ObjectOrientedProgramming.Lab2.Components.MemoryDisks.Builder;

public interface IHddBuilder
{
    IHddBuilder WithCapacity(int capacity);
    IHddBuilder WithRotationSpeed(int speed);
    IHddBuilder WithPower(int power);
    IMemoryDisk Build();
}