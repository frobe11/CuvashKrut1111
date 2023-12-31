using Itmo.ObjectOrientedProgramming.Lab1.Engines.Model;
using Itmo.ObjectOrientedProgramming.Lab1.Spacecrafts.Model;

namespace Itmo.ObjectOrientedProgramming.Lab1.Engines.Entity;

public class EngineC : IImpulseEngine
{
    private const int Speed = 10;
    private const int FuelConsumptionFoUnitOfTime = 2;
    private const int StartFuelConsumption = 5;

    public EngineWorkResult Work(int distance)
    {
        int time = distance / Speed;
        var specialFuelUsage = new SpecialFuelUsage();
        var defaultFuelUsage = new DefaultFuelUsage();
        defaultFuelUsage.Quantity += (time * FuelConsumptionFoUnitOfTime) + StartFuelConsumption;
        return new EngineWorkResult.Success(time, defaultFuelUsage, specialFuelUsage);
    }
}