namespace Itmo.ObjectOrientedProgramming.Lab2.Components.PowerUnit.Builder;

public class PowerUnitBuilder : IPowerUnitBuilder
{
    private int _power;
    public IPowerUnitBuilder WithPower(int power)
    {
        _power = power;
        return this;
    }

    public IPowerUnit Build()
    {
        return new PowerUnit(_power);
    }
}