using Itmo.ObjectOrientedProgramming.Lab1.Deflectors.Entity;
using Itmo.ObjectOrientedProgramming.Lab1.Obstacles.Model;
using Itmo.ObjectOrientedProgramming.Lab1.Spacecrafts.Entity;

namespace Itmo.ObjectOrientedProgramming.Lab1.Obstacles.Entity;

public class AntimatterFlare : INebulaeOfIncreasedDensityObstacle
{
    private const int Damage = 1;
    public AntimatterFlare() { }

    public DealDamageResult DealDamage(ISpacecraft spacecraft)
    {
        if (spacecraft is not ISpacecraftWithDeflector spacecraftWithDeflector)
            return new DealDamageResult.CrewDied();
        if (spacecraftWithDeflector.Deflector is not IDeflectorWithPhotonDeflector deflectorWithPhotonDeflector)
            return new DealDamageResult.CrewDied();
        TakeDamageResult result = deflectorWithPhotonDeflector.PhotonDeflector.TakeDamage(Damage);
        if (result is TakeDamageResult.DamageAbsorbed)
            return new DealDamageResult.DamageAbsorbed();

        return new DealDamageResult.CrewDied();
    }
}