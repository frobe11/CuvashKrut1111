using Itmo.ObjectOrientedProgramming.Lab1.Engines.Model;
using Itmo.ObjectOrientedProgramming.Lab1.Spacecrafts.Model;

namespace Itmo.ObjectOrientedProgramming.Lab1.Engines.Entity;

public class JumpEngineAlpha : IJumpEngine
{
    private const int JumpTime = 5;
    private const int JumpDistance = 1000;
    public EngineWorkResult Work(int distance)
    {
        if (distance > JumpDistance)
            return new EngineWorkResult.UnSuccess();
        var specialFuelUsage = new SpecialFuelUsage();
        var defaultFuelUsage = new DefaultFuelUsage();
        specialFuelUsage.Quantity += distance;
        return new EngineWorkResult.Success(JumpTime, defaultFuelUsage, specialFuelUsage);
    }
}