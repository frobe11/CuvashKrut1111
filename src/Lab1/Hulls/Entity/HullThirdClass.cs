using System;
using Itmo.ObjectOrientedProgramming.Lab1.Obstacles.Model;

namespace Itmo.ObjectOrientedProgramming.Lab1.Hulls.Entity;

public class HullThirdClass : IHull
{
    private double _hitPoints;

    public HullThirdClass(int mass)
    {
        _hitPoints = 100 * mass;
    }

    public TakeDamageResult TakeDamage(int damage)
    {
        {
            double coefficient;
            if (damage < (int)LowestDamage.Medium)
            {
                coefficient = 2;
            }
            else if (damage < (int)LowestDamage.High)
            {
                coefficient = 2;
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
            int freeDamage = Convert.ToInt32(freeCoefDamage / coefficient);
            return new TakeDamageResult.DamageNotAbsorbed(freeDamage);
        }
    }
}