using System;
using Itmo.ObjectOrientedProgramming.Lab1.Engines.Model;
using Itmo.ObjectOrientedProgramming.Lab1.Spacecrafts.Model;

namespace Itmo.ObjectOrientedProgramming.Lab1.Engines.Entity;

public class JumpEngineOmega : IJumpEngine
{
    private const int JumpTime = 5;
    private const int JumpDistance = 2000;
    public EngineWorkResult Work(int distance)
    {
        if (distance > JumpDistance)
            return new EngineWorkResult.UnSuccess();
        var specialFuelUsage = new SpecialFuelUsage();
        var defaultFuelUsage = new DefaultFuelUsage();
        specialFuelUsage.Quantity += (int)(distance * Math.Log2(distance));
        return new EngineWorkResult.Success(JumpTime, defaultFuelUsage, specialFuelUsage);
    }
}