using Itmo.ObjectOrientedProgramming.Lab2.Components.MicroComponents;

namespace Itmo.ObjectOrientedProgramming.Lab2.Components.MemoryDisks.Builder;

public class SsdBuilder : ISsdBuilder
{
    private int _capavity;
    private MemoryDiskConnectionOption _connectionOption;
    private int _maxSpeed;
    private int _power;
    public ISsdBuilder WithCapacity(int capacity)
    {
        _capavity = capacity;
        return this;
    }

    public ISsdBuilder WithConnectionOption(MemoryDiskConnectionOption connectionOption)
    {
        _connectionOption = connectionOption;
        return this;
    }

    public ISsdBuilder WithMaxSpeed(int speed)
    {
        _maxSpeed = speed;
        return this;
    }

    public ISsdBuilder WithPower(int power)
    {
        _power = power;
        return this;
    }

    public IMemoryDisk Build()
    {
        return new Ssd(_capavity, _power, _connectionOption, _maxSpeed);
    }
}