using Itmo.ObjectOrientedProgramming.Lab1.Spacecrafts.Model;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environments.Model;

public abstract record EnterWithResult
{
    private EnterWithResult() { }

    public record Success(int Time, DefaultFuelUsage DefaultFuelUsage, SpecialFuelUsage SpecialFuelUsage) : EnterWithResult;

    public record SpacecraftDestroyed() : EnterWithResult;

    public record CrewDied() : EnterWithResult;

    public record SpacecraftLost() : EnterWithResult;
}