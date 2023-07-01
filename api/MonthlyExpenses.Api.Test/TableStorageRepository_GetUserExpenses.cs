using Azure;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using MonthlyExpenses.Api.Models;
using MonthlyExpenses.Api.Repository;
using MonthlyExpenses.Api.Repository.Repository;
using MonthlyExpenses.Api.Test.Fakes;
using Moq;
using System.Text.Json;

namespace MonthlyExpenses.Api.Test;

public class TableStorageRepository_GetUserExpenses
{
    private const string EntityId = "123";
    private const string UsreName = "Test User";

    [Fact]
    public async Task GetUserExpenses_ShouldReturnExpenseData()
    {
        var (sut, table) = Setup();
        var expenses = CreateExpenses();

        SetGetEntityResponse(table, expenses);

        var result = await GetUserExpenses(sut);
        result.Should().BeOfType<UserExpenses>();
        result.Should().Be(expenses);
    }

    private static void SetGetEntityResponse(Mock<ITableClient> table, UserExpenses expenses)
    {
        var entity = new UserExpenseEntity();
        entity.Expenses = JsonSerializer.Serialize(expenses);
        NullableResponse<UserExpenseEntity> nullableResponse = new FakeResponse<UserExpenseEntity>(true, entity);
        table.Setup(x => x.GetEntityIfExistsAsync<UserExpenseEntity>(It.IsAny<string>(), EntityId)).Returns(Task.FromResult(nullableResponse));
    }

    private static (TableStorageRepository sut, Mock<ITableClient> table) Setup()
    {
        var factory = new Mock<ITableClientFactory>();
        var table = new Mock<ITableClient>();
        factory.Setup(x => x.GetExpensesTable()).Returns(Task.FromResult(table.Object));
        var sut = new TableStorageRepository(factory.Object);
        return (sut, table);
    }

    private static Task<UserExpenses> GetUserExpenses(TableStorageRepository sut)
    {
        var user = new User(EntityId, UsreName);
        var logger = new Mock<ILogger>();
        var result = sut.GetUserExpenses(user, logger.Object);
        return result;
    }

    private static UserExpenses CreateExpenses()
    {
        return new UserExpenses
        {
            User = UsreName,
            Months = new[]
            {
                new MonthData
                {
                    MonthStart = new DateTime(2023, 6, 1),
                    Income = new Dictionary<string, decimal>
                    {
                        { "Salary", 2000 },
                        { "Overtime", 200 },
                    },
                    Outgoings = new Dictionary<string, decimal>
                    {
                        { "Rent", 500 },
                        { "Car", 100 },
                        { "Phone", 30 },
                        { "Internet", 40 },
                        { "Food", 300 },
                    },
                },
            },
        };
    }
}
