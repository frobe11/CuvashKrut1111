using Itmo.ObjectOrientedProgramming.Lab1.Obstacles.Model;

namespace Itmo.ObjectOrientedProgramming.Lab1.Deflectors.Entity;

public abstract class DeflectorDecorator : IDeflector
{
    private IDeflector _deflector;
    protected DeflectorDecorator(IDeflector deflector)
    {
        _deflector = deflector;
    }

    public TakeDamageResult TakeDamage(int damage)
    {
        return _deflector.TakeDamage(damage);
    }
}