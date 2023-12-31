using Itmo.ObjectOrientedProgramming.Lab1.Obstacles.Model;

namespace Itmo.ObjectOrientedProgramming.Lab1.Deflectors.Entity;

public interface IDeflector
{
    TakeDamageResult TakeDamage(int damage);
}