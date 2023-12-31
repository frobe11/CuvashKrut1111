using Itmo.ObjectOrientedProgramming.Lab1.Obstacles.Model;
using Itmo.ObjectOrientedProgramming.Lab1.Spacecrafts;
using Itmo.ObjectOrientedProgramming.Lab1.Spacecrafts.Entity;

namespace Itmo.ObjectOrientedProgramming.Lab1.Obstacles.Entity;

public class SpaceWhale : INebulaeOfNitrineParticlesObstacle
{
    private const int Damage = 1000;
    public SpaceWhale() { }

    public DealDamageResult DealDamage(ISpacecraft spacecraft)
    {
        if (spacecraft is ISpacecraftWithAntinitrineEmitter)
            return new DealDamageResult.DamageAbsorbed();
        TakeDamageResult result = spacecraft.TakeDamage(Damage);
        if (result is TakeDamageResult.DamageNotAbsorbed)
            return new DealDamageResult.SpacecraftDestroyed();
        return new DealDamageResult.DamageAbsorbed();
    }
}