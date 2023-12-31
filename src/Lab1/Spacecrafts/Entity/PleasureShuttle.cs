using Itmo.ObjectOrientedProgramming.Lab1.Engines.Entity;
using Itmo.ObjectOrientedProgramming.Lab1.Hulls.Entity;
using Itmo.ObjectOrientedProgramming.Lab1.Obstacles.Model;

namespace Itmo.ObjectOrientedProgramming.Lab1.Spacecrafts.Entity;

public class PleasureShuttle : ISpacecraft, ISpacecraftWithImpulseEngine
{
    private IHull _hull;
    public PleasureShuttle()
    {
        ImpulseEngine = new EngineC();
        _hull = new HullFirstClass(1);
    }

    public IImpulseEngine ImpulseEngine { get; }

    public TakeDamageResult TakeDamage(int damage)
    {
        return _hull.TakeDamage(damage);
    }
}