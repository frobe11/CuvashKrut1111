using Itmo.ObjectOrientedProgramming.Lab1.Obstacles.Model;

namespace Itmo.ObjectOrientedProgramming.Lab1.Spacecrafts.Entity;

public interface ISpacecraft
{
    TakeDamageResult TakeDamage(int damage);
}