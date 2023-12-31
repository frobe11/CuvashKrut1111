using Itmo.ObjectOrientedProgramming.Lab1.Environments.Model;
using Itmo.ObjectOrientedProgramming.Lab1.Spacecrafts.Entity;
namespace Itmo.ObjectOrientedProgramming.Lab1.Environments.Entity;

public interface IEnvironment
{
    EnterWithResult EnterWith(ISpacecraft spacecraft);
}