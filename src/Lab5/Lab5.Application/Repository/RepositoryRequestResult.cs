namespace Lab5.Application.Repository;

public record RepositoryRequestResult
{
    private RepositoryRequestResult() { }
    public record Success() : RepositoryRequestResult;
    public record Failure(string What) : RepositoryRequestResult;
}