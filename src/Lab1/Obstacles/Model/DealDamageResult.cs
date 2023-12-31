namespace Itmo.ObjectOrientedProgramming.Lab1.Obstacles.Model;

public abstract record DealDamageResult
{
    private DealDamageResult() { }

    public record DamageAbsorbed() : DealDamageResult;

    public record CrewDied() : DealDamageResult;

    public record SpacecraftDestroyed() : DealDamageResult;
}