using Itmo.ObjectOrientedProgramming.Lab1.Obstacles.Model;

namespace Itmo.ObjectOrientedProgramming.Lab1.Deflectors.Entity;

public class DeflectorFirstClass : IDeflector
{
    private int _hitPoints;

    public DeflectorFirstClass()
    {
        _hitPoints = 100;
    }

    public TakeDamageResult TakeDamage(int damage)
    {
        int freeDamage = damage - _hitPoints;
        _hitPoints -= damage;
        if (freeDamage < 0)
            freeDamage = 0;
        if (_hitPoints < 0)
            _hitPoints = 0;
        if (_hitPoints > 0)
            return new TakeDamageResult.DamageAbsorbed();
        return new TakeDamageResult.DamageNotAbsorbed(freeDamage);
    }
}