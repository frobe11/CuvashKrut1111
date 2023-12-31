using Itmo.ObjectOrientedProgramming.Lab1.Obstacles.Model;

namespace Itmo.ObjectOrientedProgramming.Lab1.Hulls.Entity;

public interface IHull
{
    TakeDamageResult TakeDamage(int damage);
}