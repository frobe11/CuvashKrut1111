using Itmo.ObjectOrientedProgramming.Lab1.Obstacles.Model;
using Itmo.ObjectOrientedProgramming.Lab1.Spacecrafts.Entity;

namespace Itmo.ObjectOrientedProgramming.Lab1.Obstacles.Entity;

public interface IObstacle
{
    DealDamageResult DealDamage(ISpacecraft spacecraft);
}