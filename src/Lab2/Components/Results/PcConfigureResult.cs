namespace Itmo.ObjectOrientedProgramming.Lab2.Components.Results;

public abstract record PcConfigureResult
{
    private PcConfigureResult() { }

    public record Warning() : PcConfigureResult;

    public record NoWarns(bool Guarantee) : PcConfigureResult;
}