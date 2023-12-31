using Itmo.ObjectOrientedProgramming.Lab1.Engines.Entity;

namespace Itmo.ObjectOrientedProgramming.Lab1.Spacecrafts.Entity;

public interface ISpacecraftWithImpulseEngine
{
    IImpulseEngine ImpulseEngine { get; }
}