namespace Lab5.Infrastructure.DB;

public interface IDataBase
{
    Task SetUp();
    Task TearDown();
}