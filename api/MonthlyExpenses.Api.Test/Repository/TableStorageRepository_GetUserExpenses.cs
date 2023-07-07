// <copyright file="TableStorageRepository_GetUserExpenses.cs" company="Simon Stanford">
// Copyright (c) Simon Stanford. All rights reserved.
// </copyright>

using Azure;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using MonthlyExpenses.Api.Models;
using MonthlyExpenses.Api.Repository;
using MonthlyExpenses.Api.Test.Fakes;
using MonthlyExpenses.Api.Test.Helpers;
using MonthlyExpenses.Api.Utils;
using Moq;

namespace MonthlyExpenses.Api.Test.Repository;

public class TableStorageRepository_GetUserExpenses : TableStorageRepositoryBase
{
    [Fact]
    public async Task GetUserExpenses_ShouldReturnExpenseData()
    {
        var (sut, table) = Setup();
        var expenses = Creator.CreateExpenses(UserName);
        SetGetEntityResponse(table, expenses);
        var result = await GetUserExpenses(sut);
        result.Should().BeOfType<UserExpenses>();
        result.Should().Be(expenses);
    }

    [Fact]
    public async Task GetUserExpenses_WhenNoExpenesDataFound_ShouldReturnEmptyObject()
    {
        var (sut, table) = Setup();
        SetGetEntityResponse(table, null!);
        var result = await GetUserExpenses(sut);
        result.Should().BeOfType<UserExpenses>();
        result.User.Should().Be(UserName);
        result.Months.Should().HaveCount(0);
    }

    [Fact]
    public void GetUserExpenses_WhenExceptionThrown_ShouldRaiseException()
    {
        var (sut, table) = Setup();
        table.Setup(x => x.GetEntityIfExistsAsync<UserExpenseEntity>(It.IsAny<string>(), EntityId)).Throws<Exception>();
        Action action = () => GetUserExpenses(sut).Wait();
        action.Should().Throw<Exception>();
    }

    private static void SetGetEntityResponse(Mock<ITableClient> table, UserExpenses expenses)
    {
        var entity = new UserExpenseEntity();
        NullableResponse<UserExpenseEntity> nullableResponse;

        if (expenses != null)
        {
            entity.Expenses = Serializer.Serialize(expenses);
            nullableResponse = new FakeResponse<UserExpenseEntity>(true, entity);
        }
        else
        {
            nullableResponse = new FakeResponse<UserExpenseEntity>(false, null!);
        }

        table.Setup(x => x.GetEntityIfExistsAsync<UserExpenseEntity>(It.IsAny<string>(), EntityId)).Returns(Task.FromResult(nullableResponse));
    }

    private static Task<UserExpenses> GetUserExpenses(TableStorageRepository sut)
    {
        var user = CreateUser();
        var logger = new Mock<ILogger>();
        var result = sut.GetUserExpenses(user, logger.Object);
        return result;
    }
}
