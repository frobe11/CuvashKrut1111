namespace Itmo.ObjectOrientedProgramming.Lab2.Components.PowerUnit.Builder;

public interface IPowerUnitBuilder
{
    IPowerUnitBuilder WithPower(int power);
    IPowerUnit Build();
}