// <copyright file="TableStorageRepository_SaveUserExpenses.cs" company="Simon Stanford">
// Copyright (c) Simon Stanford. All rights reserved.
// </copyright>

using FluentAssertions;
using Microsoft.Extensions.Logging;
using MonthlyExpenses.Api.Models;
using MonthlyExpenses.Api.Repository;
using MonthlyExpenses.Api.Test.Helpers;
using MonthlyExpenses.Api.Utils;
using Moq;

namespace MonthlyExpenses.Api.Test.Repository;

public class TableStorageRepository_SaveUserExpenses : TableStorageRepositoryBase
{
    [Fact]
    public async Task SaveUserExpenses_ShouldCallUpsertEntityAsync()
    {
        var (sut, table) = Setup();
        var expense = Creator.CreateExpenses(UserName);
        await SaveUserExpenses(sut, expense);
        table.Verify(x => x.UpsertEntityAsync(It.Is<UserExpenseEntity>(x => ValidateExpenseEntity(x, expense))));
    }

    [Fact]
    public void SaveUserExpenses_WhenExceptionThrow_ShouldRethrow()
    {
        var (sut, table) = Setup();
        table.Setup(x => x.UpsertEntityAsync(It.IsAny<UserExpenseEntity>())).Throws<InvalidOperationException>();
        var expense = Creator.CreateExpenses(UserName);
        Action action = () => SaveUserExpenses(sut, expense).Wait();
        action.Should().Throw<InvalidOperationException>();
    }

    private static bool ValidateExpenseEntity(UserExpenseEntity entity, UserExpenses expenses)
    {
        var entityExpense = Serializer.Deserialize<UserExpenses>(entity.Expenses);
        return Equals(entityExpense, expenses);
    }

    private static Task SaveUserExpenses(TableStorageRepository sut, UserExpenses expenses)
    {
        User user = CreateUser();
        var logger = new Mock<ILogger>();
        return sut.SaveUserExpenses(user, expenses, logger.Object);
    }
}
