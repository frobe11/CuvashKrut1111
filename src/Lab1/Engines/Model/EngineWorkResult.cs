using Itmo.ObjectOrientedProgramming.Lab1.Spacecrafts.Model;

namespace Itmo.ObjectOrientedProgramming.Lab1.Engines.Model;

public abstract record EngineWorkResult
{
    private EngineWorkResult() { }

    public record Success(int Time, DefaultFuelUsage DefaultFuelUsage, SpecialFuelUsage SpecialFuelUsage) : EngineWorkResult;

    public record UnSuccess() : EngineWorkResult;
}