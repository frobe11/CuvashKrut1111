using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Engines.Model;
using Itmo.ObjectOrientedProgramming.Lab1.Environments.Model;
using Itmo.ObjectOrientedProgramming.Lab1.Obstacles.Entity;
using Itmo.ObjectOrientedProgramming.Lab1.Obstacles.Model;
using Itmo.ObjectOrientedProgramming.Lab1.Spacecrafts.Entity;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environments.Entity;

public class NebulaeOfNitrineParticles : IEnvironment
{
    private int _distance;
    private IEnumerable<INebulaeOfNitrineParticlesObstacle> _obstacles;
    public NebulaeOfNitrineParticles(int distance, IEnumerable<INebulaeOfNitrineParticlesObstacle> obstacles)
    {
        _distance = distance * 5;
        _obstacles = obstacles;
    }

    public EnterWithResult EnterWith(ISpacecraft spacecraft)
    {
        foreach (INebulaeOfNitrineParticlesObstacle obstacle in _obstacles)
        {
            DealDamageResult result = obstacle.DealDamage(spacecraft);
            switch (result)
            {
                case DealDamageResult.SpacecraftDestroyed:
                    return new EnterWithResult.SpacecraftDestroyed();
                case DealDamageResult.CrewDied:
                    return new EnterWithResult.CrewDied();
            }
        }

        if (spacecraft is not ISpacecraftWithImpulseEngine haveImpulseEngine)
            return new EnterWithResult.SpacecraftLost();
        EngineWorkResult engineWorkResult = haveImpulseEngine.ImpulseEngine.Work(_distance);
        if (engineWorkResult is EngineWorkResult.Success success)
        {
            return new EnterWithResult.Success(success.Time, success.DefaultFuelUsage, success.SpecialFuelUsage);
        }

        return new EnterWithResult.SpacecraftLost();
    }
}