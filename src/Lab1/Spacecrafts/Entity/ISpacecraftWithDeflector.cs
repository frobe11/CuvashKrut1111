using Itmo.ObjectOrientedProgramming.Lab1.Deflectors.Entity;

namespace Itmo.ObjectOrientedProgramming.Lab1.Spacecrafts.Entity;

public interface ISpacecraftWithDeflector
{
    IDeflector Deflector { get; }
}