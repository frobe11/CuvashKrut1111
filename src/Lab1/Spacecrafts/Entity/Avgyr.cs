using Itmo.ObjectOrientedProgramming.Lab1.Deflectors.Entity;
using Itmo.ObjectOrientedProgramming.Lab1.Engines.Entity;
using Itmo.ObjectOrientedProgramming.Lab1.Hulls.Entity;
using Itmo.ObjectOrientedProgramming.Lab1.Obstacles.Model;

namespace Itmo.ObjectOrientedProgramming.Lab1.Spacecrafts.Entity;

public class Avgyr : ISpacecraft, ISpacecraftWithImpulseEngine, ISpacecraftWithJumpEngine, ISpacecraftWithDeflector
{
    private IHull _hull;
    public Avgyr(bool withPhotonDeflector = false)
    {
        ImpulseEngine = new EngineE();
        JumpEngine = new JumpEngineAlpha();
        if (withPhotonDeflector)
            Deflector = new DeflectorWithPhotonDeflector(new DeflectorThirdClass());
        else
            Deflector = new DeflectorThirdClass();
        _hull = new HullThirdClass(3);
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