using Itmo.ObjectOrientedProgramming.Lab1.Obstacles.Model;
using Itmo.ObjectOrientedProgramming.Lab1.Spacecrafts.Entity;

namespace Itmo.ObjectOrientedProgramming.Lab1.Obstacles.Entity;

public class Meteor : ISpaceObstacle
{
    private const int Damage = 100;
    public Meteor() { }

    public DealDamageResult DealDamage(ISpacecraft spacecraft)
    {
        TakeDamageResult result = spacecraft.TakeDamage(Damage);
        if (result is TakeDamageResult.DamageNotAbsorbed)
            return new DealDamageResult.SpacecraftDestroyed();
        return new DealDamageResult.DamageAbsorbed();
    }
}