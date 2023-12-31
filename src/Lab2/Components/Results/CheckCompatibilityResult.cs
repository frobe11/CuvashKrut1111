namespace Itmo.ObjectOrientedProgramming.Lab2.Components.Results;

public abstract record CheckCompatibilityResult
{
    private CheckCompatibilityResult() { }
    public record Сompatible() : CheckCompatibilityResult;

    public record NotСompatible(IComponent First, IComponent Second) : CheckCompatibilityResult;
}