namespace Lab5.Application.Services.Contracts;

public record OperationResult
{
    private OperationResult() { }

    public record Success() : OperationResult;
    public record Failure(string What) : OperationResult;
}