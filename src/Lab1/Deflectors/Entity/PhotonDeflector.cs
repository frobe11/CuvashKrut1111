using Itmo.ObjectOrientedProgramming.Lab1.Obstacles.Model;

namespace Itmo.ObjectOrientedProgramming.Lab1.Deflectors.Entity;

public class PhotonDeflector : IPhotonDeflector
{
    private double _hitPoints;

    public PhotonDeflector()
    {
        _hitPoints = 3;
    }

    public TakeDamageResult TakeDamage(int damage)
    {
        _hitPoints -= damage;
        if (_hitPoints < 0)
            return new TakeDamageResult.DamageNotAbsorbed(damage);
        return new TakeDamageResult.DamageAbsorbed();
    }
}