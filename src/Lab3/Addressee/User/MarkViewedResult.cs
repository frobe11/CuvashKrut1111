namespace Itmo.ObjectOrientedProgramming.Lab3.Addressee.User;

public abstract record MarkViewedResult
{
    protected MarkViewedResult()
    { }
    public record Marked() : MarkViewedResult();
    public record NotMarked() : MarkViewedResult();
}