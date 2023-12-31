using Itmo.ObjectOrientedProgramming.Lab1.Deflectors.Entity;
using Itmo.ObjectOrientedProgramming.Lab1.Engines.Entity;
using Itmo.ObjectOrientedProgramming.Lab1.Hulls.Entity;
using Itmo.ObjectOrientedProgramming.Lab1.Obstacles.Model;

namespace Itmo.ObjectOrientedProgramming.Lab1.Spacecrafts.Entity;

public class Meredian : ISpacecraft, ISpacecraftWithImpulseEngine, ISpacecraftWithAntinitrineEmitter, ISpacecraftWithDeflector
{
    private IHull _hull;
    public Meredian(bool withPhotonDeflector = false)
    {
        _hull = new HullSecondClass(2);
        ImpulseEngine = new EngineE();
        if (withPhotonDeflector)
            Deflector = new DeflectorWithPhotonDeflector(new DeflectorSecondClass());
        else
            Deflector = new DeflectorSecondClass();
    }

    public IDeflector Deflector { get; }
    public IImpulseEngine ImpulseEngine { get; }
    public TakeDamageResult TakeDamage(int damage)
    {
        TakeDamageResult result = Deflector.TakeDamage(damage);
        if (result is not TakeDamageResult.DamageNotAbsorbed damageNotAbsorbed) return result;
        damage = damageNotAbsorbed.Damage;
        return _hull.TakeDamage(damage);
    }
}