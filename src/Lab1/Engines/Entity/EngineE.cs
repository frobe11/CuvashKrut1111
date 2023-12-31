using System;
using Itmo.ObjectOrientedProgramming.Lab1.Engines.Model;
using Itmo.ObjectOrientedProgramming.Lab1.Spacecrafts.Model;

namespace Itmo.ObjectOrientedProgramming.Lab1.Engines.Entity;

public class EngineE : IImpulseEngine
{
    private const int FuelConsumptionFoUnitOfTime = 10;
    private const int StartFuelConsumption = 50;
    public EngineWorkResult Work(int distance)
    {
        int time = 0;
        while (distance > 0)
        {
            distance -= (int)Math.Exp(time);
            time++;
        }

        var specialFuelUsage = new SpecialFuelUsage();
        var defaultFuelUsage = new DefaultFuelUsage();
        defaultFuelUsage.Quantity += (time * FuelConsumptionFoUnitOfTime) + StartFuelConsumption;
        return new EngineWorkResult.Success(time, defaultFuelUsage, specialFuelUsage);
    }
}