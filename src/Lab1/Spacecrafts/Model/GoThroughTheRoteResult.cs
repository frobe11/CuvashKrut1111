using Itmo.ObjectOrientedProgramming.Lab1.Spacecrafts.Entity;

namespace Itmo.ObjectOrientedProgramming.Lab1.Spacecrafts.Model;

public abstract record GoThroughTheRoteResult
{
    private GoThroughTheRoteResult() { }

    public record Success(int Time, int FuelPrice, ISpacecraft Spacecraft) : GoThroughTheRoteResult;

    public record SpacecraftLost() : GoThroughTheRoteResult;

    public record SpacecraftDestroyed() : GoThroughTheRoteResult;

    public record CrewDied() : GoThroughTheRoteResult;
}