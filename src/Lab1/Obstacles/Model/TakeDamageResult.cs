namespace Itmo.ObjectOrientedProgramming.Lab1.Obstacles.Model;

public abstract record TakeDamageResult
{
    private TakeDamageResult() { }

    public record DamageAbsorbed : TakeDamageResult;

    public record DamageNotAbsorbed(int Damage) : TakeDamageResult;
}