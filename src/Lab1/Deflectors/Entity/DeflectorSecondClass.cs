using Itmo.ObjectOrientedProgramming.Lab1.Obstacles.Model;

namespace Itmo.ObjectOrientedProgramming.Lab1.Deflectors.Entity;

public class DeflectorSecondClass : IDeflector
{
    private double _hitPoints;

    public DeflectorSecondClass()
    {
        _hitPoints = 100;
    }

    public TakeDamageResult TakeDamage(int damage)
    {
        double coefficient;
        if (damage < (int)LowestDamage.Medium)
        {
            coefficient = 0.2;
        }
        else if (damage < (int)LowestDamage.High)
        {
            coefficient = 0.33;
        }
        else
        {
            coefficient = 1;
        }

        double coefDamage = damage * coefficient;
        double freeCoefDamage = coefDamage - _hitPoints;
        _hitPoints -= damage;
        if (freeCoefDamage < 0)
            freeCoefDamage = 0;
        if (_hitPoints < 0)
            _hitPoints = 0;
        if (_hitPoints > 0)
            return new TakeDamageResult.DamageAbsorbed();
        int freeDamage = (int)(freeCoefDamage / coefficient);
        return new TakeDamageResult.DamageNotAbsorbed(freeDamage);
    }
}