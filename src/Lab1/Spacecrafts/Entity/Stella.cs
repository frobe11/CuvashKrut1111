using Itmo.ObjectOrientedProgramming.Lab1.Deflectors.Entity;
using Itmo.ObjectOrientedProgramming.Lab1.Engines.Entity;
using Itmo.ObjectOrientedProgramming.Lab1.Hulls.Entity;
using Itmo.ObjectOrientedProgramming.Lab1.Obstacles.Model;

namespace Itmo.ObjectOrientedProgramming.Lab1.Spacecrafts.Entity;

public class Stella : ISpacecraft, ISpacecraftWithImpulseEngine, ISpacecraftWithJumpEngine, ISpacecraftWithDeflector
{
    private IHull _hull;
    public Stella(bool withPhotonDeflector = false)
    {
        ImpulseEngine = new EngineC();
        JumpEngine = new JumpEngineOmega();
        _hull = new HullFirstClass(1);
        if (withPhotonDeflector)
            Deflector = new DeflectorWithPhotonDeflector(new DeflectorFirstClass());
        else
            Deflector = new DeflectorFirstClass();
    }

    public IDeflector Deflector { get; }
    public IImpulseEngine ImpulseEngine { get; }
    public IJumpEngine JumpEngine { get; }
    public TakeDamageResult TakeDamage(int damage)
    {
        TakeDamageResult result = Deflector.TakeDamage(damage);
        if (result is not TakeDamageResult.DamageNotAbsorbed damageNotAbsorbed) return result;
        damage = damageNotAbsorbed.Damage;
        return _hull.TakeDamage(damage);
    }
}