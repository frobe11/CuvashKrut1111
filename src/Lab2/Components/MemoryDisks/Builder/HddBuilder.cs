namespace Itmo.ObjectOrientedProgramming.Lab2.Components.MemoryDisks.Builder;

public class HddBuilder : IHddBuilder
{
    private int _capacity;
    private int _speed;
    private int _power;
    public IHddBuilder WithCapacity(int capacity)
    {
        _capacity = capacity;
        return this;
    }

    public IHddBuilder WithRotationSpeed(int speed)
    {
        _speed = speed;
        return this;
    }

    public IHddBuilder WithPower(int power)
    {
        _power = power;
        return this;
    }

    public IMemoryDisk Build()
    {
        return new Hdd(_power, _speed, _capacity);
    }
}