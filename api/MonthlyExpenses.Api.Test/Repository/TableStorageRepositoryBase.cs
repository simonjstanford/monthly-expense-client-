using MonthlyExpenses.Api.Repository.Repository;
using MonthlyExpenses.Api.Repository;
using Moq;
using MonthlyExpenses.Api.Models;

namespace MonthlyExpenses.Api.Test.Repository;

public class TableStorageRepositoryBase
{
    protected const string EntityId = "123";
    protected const string UserName = "Test User";

    protected static User CreateUser() => new(EntityId, UserName);

    protected static (TableStorageRepository sut, Mock<ITableClient> table) Setup()
    {
        var factory = new Mock<ITableClientFactory>();
        var table = new Mock<ITableClient>();
        factory.Setup(x => x.GetExpensesTable()).Returns(Task.FromResult(table.Object));
        var sut = new TableStorageRepository(factory.Object);
        return (sut, table);
    }
}
